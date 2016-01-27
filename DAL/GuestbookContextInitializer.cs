using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class GuestbookContextInitializer : DropCreateDatabaseAlways<GuestbookContext>
    {
        private List<Guestbook> _guestbookList;

        public GuestbookContextInitializer()
        {
            _guestbookList = new List<Guestbook>()
            {
                new Guestbook("My Guestbook", new List<Comment>()
                {
                    new Comment("Therese Sangö", "tess@gmail.com", "Operation Reinhard, även kallad Aktion Reinhard eller Einsatz Reinhard, var ett förintelseprogram som utarbetades av SS under andra världskriget och inbegrep tre förintelseläger: Bełżec, Sobibór och Treblinka. ", DateTime.Now), 
                    new Comment("Timothy Broström", "timmy@gmail.com", "Yttre Småträsket ingår i det delavrinningsområde (717345-166995) som SMHI kallar för Utloppet av Yttre Småträsket. Medelhöjden är 238 meter över havet och ytan är 13,97 kvadratkilometer. ", new DateTime(2014, 6, 10, 12, 53, 31)), 
                    new Comment("Johan Björk", "johan@gmail.com", "Pertusaria heterochroa är en lavart[1] som först beskrevs av Johannes Müller Argoviensis, och fick sitt nu gällande namn av Erichsen.", new DateTime(2011, 7, 12, 15, 01, 14)),
                    new Comment("Tim Burton", "name@gmail.com", "Ytt Långtjärnen är en sjö i Piteå kommun i Norrbotten och ingår i Lillpiteälvens huvudavrinningsområde.s", DateTime.Now), 
                    new Comment("Elizabeth Taylor", "name@gmail.com", "Opius[1] är ett släkte av steklar som beskrevs av Wesmael 1835. Opius ingår i familjen bracksteklar", new DateTime(2014, 6, 10, 12, 53, 31)), 
                    
                    new Comment("Johnny Depp", "name@gmail.com", "Cabera graciosa[1] är en fjärilsart som beskrevs av Dyar 1913. Cabera graciosa ingår i släktet Cabera och familjen mätare.", new DateTime(2011, 7, 12, 15, 01, 14)),
                    new Comment("Adam Sandler", "name@gmail.com", "60-talet var det sjunde årtiondet e.Kr. Det började 1 januari 60 e.Kr. och slutade 31 december 69 e.Kr.", DateTime.Now), 
                    new Comment("Queen of England", "name@gmail.com", "Cnemidocarpa verrucosa[1] är en sjöpungsart som först beskrevs av René-Primevère Lesson 1830. Cnemidocarpa verrucosa ingår i släktet Cnemidocarpa och familjen Styelidae.", new DateTime(2014, 6, 10, 12, 53, 31)), 
                    new Comment("Jason", "johan@gmail.com", "Hyalopomatus sikorskii[1][2] är en ringmaskart som beskrevs av Kupriyanova 1993. Hyalopomatus sikorskii ingår i släktet Hyalopomatus och familjen Serpulidae.[3][4] Inga underarter finns listade i Catalogue of Life", new DateTime(2011, 7, 12, 15, 01, 14)),
                    new Comment("Therese Sangö", "tess@gmail.com", "Operation Reinhard, även kallad Aktion Reinhard eller Einsatz Reinhard, var ett förintelseprogram som utarbetades av SS under andra världskriget och inbegrep tre förintelseläger: Bełżec, Sobibór och Treblinka. ", DateTime.Now), 
                    
                    new Comment("Timothy Broström", "timmy@gmail.com", "Yttre Småträsket ingår i det delavrinningsområde (717345-166995) som SMHI kallar för Utloppet av Yttre Småträsket. Medelhöjden är 238 meter över havet och ytan är 13,97 kvadratkilometer. ", new DateTime(2014, 6, 10, 12, 53, 31)), 
                    new Comment("Johan Björk", "johan@gmail.com", "Pertusaria heterochroa är en lavart[1] som först beskrevs av Johannes Müller Argoviensis, och fick sitt nu gällande namn av Erichsen.", new DateTime(2011, 7, 12, 15, 01, 14)),
                    new Comment("Tim Burton", "name@gmail.com", "Ytt Långtjärnen är en sjö i Piteå kommun i Norrbotten och ingår i Lillpiteälvens huvudavrinningsområde.s", DateTime.Now), 
                    new Comment("Elizabeth Taylor", "name@gmail.com", "Opius[1] är ett släkte av steklar som beskrevs av Wesmael 1835. Opius ingår i familjen bracksteklar", new DateTime(2014, 6, 10, 12, 53, 31)), 
                })
            }; //guestbooklist
        } //const

        public override void InitializeDatabase(GuestbookContext context)
        {
            _guestbookList.ForEach(g => context.Guestbooks.Add(g));
            base.InitializeDatabase(context);
        }
    }
}
