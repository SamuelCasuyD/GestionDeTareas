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
   public class gxdomaink2bbtntooltip
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomaink2bbtntooltip ()
      {
         domain["Primera"] = "First";
         domain["Anterior"] = "Previous";
         domain["Siguiente"] = "Next";
         domain["�ltima"] = "Last";
         domain["Listado"] = "List";
         domain["Actualizar"] = "Refresh";
         domain["Agregar"] = "New";
         domain["Ocultar Filtros"] = "HideFilters";
         domain["Mostrar Filtros"] = "ShowFilters";
         domain["Imprimir"] = "Print";
         domain["\"; title=\""] = "ToolTipText";
         domain["Soporte T�cnico"] = "TechSupport";
         domain["Ayuda"] = "HelpHeader";
         domain["Cerrar"] = "Close";
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
            domainMap["First"] = "Primera";
            domainMap["Previous"] = "Anterior";
            domainMap["Next"] = "Siguiente";
            domainMap["Last"] = "�ltima";
            domainMap["List"] = "Listado";
            domainMap["Refresh"] = "Actualizar";
            domainMap["New"] = "Agregar";
            domainMap["HideFilters"] = "Ocultar Filtros";
            domainMap["ShowFilters"] = "Mostrar Filtros";
            domainMap["Print"] = "Imprimir";
            domainMap["ToolTipText"] = "\"; title=\"";
            domainMap["TechSupport"] = "Soporte T�cnico";
            domainMap["Help"] = "Ayuda";
            domainMap["Close"] = "Cerrar";
         }
         return (String)domainMap[key] ;
      }

   }

}
