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
   public class gxdomaink2bstandardactivitytype
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomaink2bstandardactivitytype ()
      {
         domain["Insert"] = "Insert";
         domain["Update"] = "Update";
         domain["Delete"] = "Delete";
         domain["Maintenance"] = "Maintenance";
         domain["Visualization"] = "Visualization";
         domain["Display"] = "Display";
         domain["List"] = "List";
         domain["None"] = "None";
         domain["Other"] = "Other";
      }

      public static string getDescription( IGxContext context ,
                                           String key )
      {
         string rtkey ;
         String value ;
         rtkey = ((key==null) ? "" : StringUtil.Trim( (String)(key)));
         value = (String)(domain[rtkey]==null?"":domain[rtkey]);
         return value ;
      }

      public static GxSimpleCollection<String> getValues( )
      {
         GxSimpleCollection<String> value = new GxSimpleCollection<String>();
         ArrayList aKeys = new ArrayList(domain.Keys);
         aKeys.Sort();
         foreach (String key in aKeys)
         {
            value.Add(key);
         }
         return value;
      }

      [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
      public static String getValue( string key )
      {
         if(domainMap == null)
         {
            domainMap = new Hashtable();
            domainMap["Insert"] = "Insert";
            domainMap["Update"] = "Update";
            domainMap["Delete"] = "Delete";
            domainMap["Maintenance"] = "Maintenance";
            domainMap["Visualization"] = "Visualization";
            domainMap["Display"] = "Display";
            domainMap["List"] = "List";
            domainMap["None"] = "None";
            domainMap["Other"] = "Other";
         }
         return (String)domainMap[key] ;
      }

   }

}
