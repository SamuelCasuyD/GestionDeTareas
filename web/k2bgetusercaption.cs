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
   public class k2bgetusercaption : GXProcedure
   {
      public k2bgetusercaption( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public k2bgetusercaption( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( out String aP0_UserCaption )
      {
         this.AV8UserCaption = "" ;
         initialize();
         executePrivate();
         aP0_UserCaption=this.AV8UserCaption;
      }

      public String executeUdp( )
      {
         execute(out aP0_UserCaption);
         return AV8UserCaption ;
      }

      public void executeSubmit( out String aP0_UserCaption )
      {
         k2bgetusercaption objk2bgetusercaption;
         objk2bgetusercaption = new k2bgetusercaption();
         objk2bgetusercaption.AV8UserCaption = "" ;
         objk2bgetusercaption.context.SetSubmitInitialConfig(context);
         objk2bgetusercaption.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objk2bgetusercaption);
         aP0_UserCaption=this.AV8UserCaption;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bgetusercaption)stateInfo).executePrivate();
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
         AV8UserCaption = "User";
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

      private String AV8UserCaption ;
      private String aP0_UserCaption ;
   }

}
