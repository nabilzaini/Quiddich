﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Utilisateur 
    {
        string nom;
        string prenom;
        string login;
        string password;

        public Utilisateur(string nom, string prenom, string login, string password) {
            this.nom = nom;
            this.prenom = prenom;
            this.login = login;
            this.password = password;
        }
        public string getPassword(){return password;}
        public string getLogin() { return login; }
        public string getNom() { return nom; }
        public string getPrenom() { return prenom; }



    }
}
