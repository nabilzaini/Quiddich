﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using StubDataAccessLayer;

namespace BusinessLayer
{
   public  class CoupeManager
   {
        private DalManager data;

        public CoupeManager()
        {
            data = new DalManager();
        }
       /*
        public static List<string> allCoupes(){

            List<Coupe> coupes = data.getCoupes();
            List<string> query = (List<string>)
                from c in coupes
                select c.ToString();
            return query;
        }
       */
        public List<Coupe> allCoupes()
        {

            List<Coupe> coupes = data.getCoupes();
            /*List<Coupe> query = (List<Coupe>)
                from c in coupes
                select c;*/
            return coupes;
        }
        public List<Joueur> allJoueurs()
        {
            return data.getJoueurs();
        }
        public List<Match> allMatchOfCoupe(int idCoupe)
        {
            return data.getMatchesById(idCoupe);
        }
        public void addCoupe(int year, string libelle)
        {
            data.addCoupe(new Coupe(year, libelle));


        }
        public void addJoueur(string nom, string prenom, int score, PosteJoueur poste, int slections)
        {
            data.addJoueur(new Joueur(slections, score, poste, new DateTime(), nom, prenom));
        }

        public void addStade(string nom, string adresse, int places, double p)
        {
            data.addStade(new Stade(nom, adresse, places, p));
        }

        public void deleteEquipe(Equipe equipe)
        {
            data.deleteEquipe(equipe);
        }
        public void deleteJoueur(Joueur joueur)
        {
            data.deleteJoueur(joueur);
        }
        public void deleteStade(Stade s)
        {
            data.deleteStade(s);
        }
        public void deleteCoupe(Coupe coupe)
        {
            data.deleteCoupe(coupe);
        }
        public void addEquipe(string nom, string pays)
        {
            data.addEquipe(new Equipe(nom, pays));

        }
        public List<Equipe> allEquipes()
        {
            return data.getEquipes();
        }
        public List<Stade> allStades()
        {
            return data.getStades();
        }
        public List<Match> allMatches()
        {
            return data.getMatches();
        }

        public List<string> matchesOf(int coupeId) {
            List<Match> matches = data.getMatches();
            List<string> query = (List<string>)
                from m in matches
                where m.CoupeId == coupeId
                select m.ToString();
            return query;
        }

        public List<string> stadeOf(int coupeId)
        {
            List<Match> matches = data.getMatches();
            List<Stade> stades = data.getStades();

            List<string> query = (List<string>)
                    from s in stades 
                    where (from m in matches where m.Stade == s && m.CoupeId == coupeId select m).Count() > 0
                    select s.ToString();
            return query;
        }

        public List<string> joueursDomicleOf(int coupeId) {
            List<Match> matches = data.getMatches();
            List<Equipe> equipes = data.getEquipes();
            List<Joueur> joueurs = data.getJoueurs();

            List<string> query = (List<string>)
                    from j in joueurs
                    where j.Poste == PosteJoueur.Attrapeur &&
                    (from e in equipes
                     where (from m in matches where m.CoupeId == coupeId && m.EquipeDomicile == e select m).Count() > 0
                         && (from jj in e.getJoueurs() where jj == j select jj).Count() > 0
                     select e
                    ).Count() > 0
                    select j.ToString();
            return query;
            
        }

        public Utilisateur Login(string login, string password) {
            Utilisateur user = data.getUtilisateurByLogin(login);
            if(user !=  null)
                if(user.getPassword().Equals(password))
                    return user;
            return null;        
        }
    }
}