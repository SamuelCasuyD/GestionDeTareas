using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class gxdomainestadosgenerales
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomainestadosgenerales ()
      {
         domain[(short)1] = "Nuevo";
         domain[(short)2] = "En Progreso";
         domain[(short)3] = "Completado";
         domain[(short)4] = "Detenido";
         domain[(short)5] = "Pendiente";
      }

      public static string getDescription( IGxContext context ,
                                           short key )
      {
         String value ;
         value = (String)(domain[key]==null?"":domain[key]);
         return value ;
      }

      public static GxSimpleCollection<short> getValues( )
      {
         GxSimpleCollection<short> value = new GxSimpleCollection<short>();
         ArrayList aKeys = new ArrayList(domain.Keys);
         aKeys.Sort();
         foreach (short key in aKeys)
         {
            value.Add(key);
         }
         return value;
      }

      [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
      public static short getValue( string key )
      {
         if(domainMap == null)
         {
            domainMap = new Hashtable();
            domainMap["Nuevo"] = (short)1;
            domainMap["EnProgreso"] = (short)2;
            domainMap["Completado"] = (short)3;
            domainMap["Detenido"] = (short)4;
            domainMap["Pendiente"] = (short)5;
         }
         return (short)domainMap[key] ;
      }

   }

}
