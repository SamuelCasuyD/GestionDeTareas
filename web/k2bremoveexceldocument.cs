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
   public class k2bremoveexceldocument : GXProcedure
   {
      public k2bremoveexceldocument( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public k2bremoveexceldocument( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( String aP0_FileName )
      {
         this.AV8FileName = aP0_FileName;
         initialize();
         executePrivate();
      }

      public void executeSubmit( String aP0_FileName )
      {
         k2bremoveexceldocument objk2bremoveexceldocument;
         objk2bremoveexceldocument = new k2bremoveexceldocument();
         objk2bremoveexceldocument.AV8FileName = aP0_FileName;
         objk2bremoveexceldocument.context.SetSubmitInitialConfig(context);
         objk2bremoveexceldocument.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objk2bremoveexceldocument);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bremoveexceldocument)stateInfo).executePrivate();
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
         AV9File.Source = AV8FileName;
         AV10ret = GXUtil.Sleep( 10);
         AV9File.Delete();
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
         AV9File = new GxFile(context.GetPhysicalPath());
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV10ret ;
      private String AV8FileName ;
      private GxFile AV9File ;
   }

}
