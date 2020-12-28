using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Html;
using System.Diagnostics;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Server;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Windows;
using testx.Models;
using System.Web;
using System.IO;
using Microsoft.Data;
using Microsoft.Extensions.Configuration;
using projecto_incidencias.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace testx.Controllers
{


    public class MenuContactoController : Controller
    {

        static Random rmd = new Random();
        static int  codigo = rmd.Next(1, 999999999);
        static int  numero = 0;
        static int numero2 = 0;
        static int codigo2 = rmd.Next(1, 999999999);

    
           


        ContactoSQLiteRepository repo;
        private object Session;

        public MenuContactoController(ContactoSQLiteRepository conrepo, IConfiguration config)
        {

            repo = conrepo;
            //Url = url;
    


        }



        // GET: MenuContacto

        public ActionResult Index()
        {
            var model = repo.LeerDocumentos();
            
            return View(model);

        }



     


        // GET: MenuContacto/Details/5



        public ActionResult Detalles_Prospecto(int id)
        {


            var model = repo.LeerDocPorId(id);

            if (model == null)
            {
                return NotFound();
            }


            model.DocumentosSS = repo.LeerDocumentos();
            
            return View(model);




        }
      

        // GET: MenuContacto/Create
        public ActionResult Create()
        {
            var model = new prospecto();
         
            return View(model);
        }

        // POST: MenuContacto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(prospecto model)
        {
            try
            {

           foreach (var item in repo.LeerProspecto())
           {
               if (item.RFC.Equals(model.RFC))
               {
                   return RedirectToAction(nameof(Create));
               }
           }
                numero = codigo2;
                model.ID = numero;
              

               

            var resultado = repo.CrearProspecto(model);
         
            return RedirectToAction(nameof(Create_Document));




            }
            catch (Exception)
            {

                return RedirectToAction(nameof(Create));
            }
           
            // TODO: Add insert logic here



           
        }



 public ActionResult Create_Document()
        {
            var model = new Documento();
            model.PROPESTOSS = repo.LeerProspecto();
       
            return View(model);
        }

// POST: MenuContacto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create_Document(Documento model)
        {

            try
            {
     numero2 = codigo2;
            model.ID2 = numero2;


                if (model.ESTATUS.Equals("AUTORIZADO") || model.ESTATUS.Equals("ENVIADO"))
                {
                    model.OBSERVACIONES = ".";
                }
           
     
                foreach (var item in repo.LeerProspecto())
                {
                    if (item.ID == numero)
                    {
             
                        model.NOMBRE = item.NOMBRE;
                        model.PRIMER_APELLIDO = item.PRIMER_APELLIDO;
                    model.SEGUNDO_APELLIDO = item.SEGUNDO_APELLIDO;
                        model.NUMERO = item.NUMERO;
                        model.CALLE = item.CALLE;
                        model.CODIGO_POSTAL = item.CODIGO_POSTAL;
                    model.COLONIA = item.COLONIA;
                    model.RFC = item.RFC; 
                    model.TELEFONO = item.TELEFONO; 
                    
                      
            
                    }
                           

                }
    
              var resultado = repo.CrearDocumento(model);


                // TODO: Add insert logic her

                return RedirectToAction(nameof(Create_Document));
                ;
        
            }
            catch (Exception)
            {
               

                return RedirectToAction(nameof(Create_Document));

            }
            


           
            
  
        }




       



 public ActionResult Edit_Document(int  id)
        {
        
            var model = repo.LeerDocPorId(id);
            
            if (model == null)
            {
                return NotFound();
            }

        
            return View(model);
        }

        // POST: MenuContacto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit_Document(Documento model)
        {

 Documento contacto = new Documento();

            // TODO: Add update logic here


    if (model.ESTATUS.Equals("AUTORIZADO"))
            {
                contacto.OBSERVACIONES = ".";
            }
            else
            {
                contacto.OBSERVACIONES = model.OBSERVACIONES;   
            }

         
                   contacto.ID = contacto.ID;        
                   contacto.ID2 = model.ID2;
                   contacto.ESTATUS = model.ESTATUS;
                    contacto.NOMBRE_DEL_DOCUMENTO = model.NOMBRE_DEL_DOCUMENTO;
                    contacto.NOMBRE = model.NOMBRE;
                    contacto.PRIMER_APELLIDO = model.PRIMER_APELLIDO;
                   contacto.SEGUNDO_APELLIDO = model.SEGUNDO_APELLIDO;
                    contacto.CALLE = model.CALLE;
                    contacto.NUMERO = model.NUMERO;
                    contacto.COLONIA = model.COLONIA;
                    contacto.CODIGO_POSTAL = model.CODIGO_POSTAL;
                    contacto.TELEFONO = model.TELEFONO;
                    contacto.RFC = model.RFC;      
      
          var resultado = repo.Actualizar_Doc(contacto,model.ID2);
           
           
           
     
            
                return RedirectToAction(nameof(Index));
          
               
}

        


    }
}