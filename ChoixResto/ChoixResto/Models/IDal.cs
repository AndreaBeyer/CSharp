using ChoixResto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoixResto
{
    public interface IDal : IDisposable
    {
        void CreerRestaurant(string nom, string telephone);
        void ModifierRestaurant(int id, string nom, string telephone);
        List<Resto> ObtientTousLesRestaurants();
        bool RestaurantExiste(string nom);
        Utilisateur ObtenirUtilisateur(int id);
        Utilisateur ObtenirUtilisateur(string idStr);
        int AjouterUtilisateur(string nom, string motDePasse);
        int CreerUnSondage();
        void AjouterVote(int idSondage, int idResto, int idUtilisateur);
        List<Resultats> ObtenirLesResultats(int idSondage);
        bool ADejaVote(int idSondage, string idStr);
        Utilisateur Authentifier(string nom, string motDePasse);
    }
}
