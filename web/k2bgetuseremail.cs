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
   public class k2bgetuseremail : GXProcedure
   {
      public k2bgetuseremail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public k2bgetuseremail( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( out String aP0_UserEmail )
      {
         this.AV8UserEmail = "" ;
         initialize();
         executePrivate();
         aP0_UserEmail=this.AV8UserEmail;
      }

      public String executeUdp( )
      {
         execute(out aP0_UserEmail);
         return AV8UserEmail ;
      }

      public void executeSubmit( out String aP0_UserEmail )
      {
         k2bgetuseremail objk2bgetuseremail;
         objk2bgetuseremail = new k2bgetuseremail();
         objk2bgetuseremail.AV8UserEmail = "" ;
         objk2bgetuseremail.context.SetSubmitInitialConfig(context);
         objk2bgetuseremail.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objk2bgetuseremail);
         aP0_UserEmail=this.AV8UserEmail;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bgetuseremail)stateInfo).executePrivate();
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
         AV8UserEmail = "sample@example.com";
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
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private String AV8UserEmail ;
      private String aP0_UserEmail ;
   }

}
