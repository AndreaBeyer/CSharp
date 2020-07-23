using ChoixResto.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ChoixResto
{
    public class Dal : IDal
    {
        private BddContext bdd;

        public Dal()
        {
            bdd = new BddContext();
        }

        public List<Resto> ObtientTousLesRestaurants()
        {
            return bdd.Restos.ToList();
        }

        public void Dispose()
        {
            bdd.Dispose();
        }

        public void CreerRestaurant(string nom, string telephone)
        {
            bdd.Restos.Add(new Resto { Nom = nom, Telephone = telephone });
            bdd.SaveChanges();
        }

        public void ModifierRestaurant(int id, string nom, string telephone)
        {
            Resto restoTrouve = bdd.Restos.FirstOrDefault(resto => resto.Id == id);
            if (restoTrouve != null)
            {
                restoTrouve.Nom = nom;
                restoTrouve.Telephone = telephone;
                bdd.SaveChanges();
            }
        }

        public bool RestaurantExiste(string nom)
        {
            Resto restoTrouve = bdd.Restos.FirstOrDefault(resto => resto.Nom == nom);
            return restoTrouve != null;
        }

        public Utilisateur ObtenirUtilisateur(int id)
        {
            return bdd.Utilisateurs.FirstOrDefault(user => user.Id == id);
        }

        public Utilisateur ObtenirUtilisateur(string idStr)
        {
            if (int.TryParse(idStr, out int id))
            {
                return ObtenirUtilisateur(id);
            }
            else return null;
        }

        public int AjouterUtilisateur(string nom, string motDePasse)
        {
            throw new NotImplementedException();
        }

        public int CreerUnSondage()
        {
            Sondage sondage = new Sondage { Date = DateTime.Now };
            bdd.Sondages.Add(sondage);
            bdd.SaveChanges();
            return sondage.Id;
        }

        public void AjouterVote(int idSondage, int idResto, int idUtilisateur)
        {
            throw new NotImplementedException();
        }

        public List<Resultats> ObtenirLesResultats(int idSondage)
        {
            throw new NotImplementedException();
        }

        public bool ADejaVote(int idSondage, string idStr)
        {
            throw new NotImplementedException();
        }

        public Utilisateur Authentifier(string nom, string motDePasse)
        {
            throw new NotImplementedException();
        }

        private string EncodeMD5(string motDePasse)
        {
            string motDePasseSel = "ChoixResto" + motDePasse + "ASP.NET MVC";
            return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(Encoding.Default.GetBytes(motDePasseSel)));
        }
    }
}