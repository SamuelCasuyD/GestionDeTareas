using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class k2btoolsgetuseencryption : GXProcedure
   {
      public k2btoolsgetuseencryption( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public k2btoolsgetuseencryption( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( out String aP0_encrypt )
      {
         this.AV9encrypt = "" ;
         initialize();
         executePrivate();
         aP0_encrypt=this.AV9encrypt;
      }

      public String executeUdp( )
      {
         execute(out aP0_encrypt);
         return AV9encrypt ;
      }

      public void executeSubmit( out String aP0_encrypt )
      {
         k2btoolsgetuseencryption objk2btoolsgetuseencryption;
         objk2btoolsgetuseencryption = new k2btoolsgetuseencryption();
         objk2btoolsgetuseencryption.AV9encrypt = "" ;
         objk2btoolsgetuseencryption.context.SetSubmitInitialConfig(context);
         objk2btoolsgetuseencryption.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objk2btoolsgetuseencryption);
         aP0_encrypt=this.AV9encrypt;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2btoolsgetuseencryption)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw e ;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9encrypt = AV8ConfigurationManager.getvalue("USE_ENCRYPTION");
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections() ;
         }
         exitApplication();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         AV8ConfigurationManager = new GeneXus.Core.genexus.common.configuration.SdtConfigurationManager(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private String AV9encrypt ;
      private GeneXus.Core.genexus.common.configuration.SdtConfigurationManager AV8ConfigurationManager ;
      private String aP0_encrypt ;
   }

}
