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
   public class k2bsessionset : GXProcedure
   {
      public k2bsessionset( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public k2bsessionset( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( String aP0_SessionItem ,
                           String aP1_SessionData )
      {
         this.AV8SessionItem = aP0_SessionItem;
         this.AV9SessionData = aP1_SessionData;
         initialize();
         executePrivate();
      }

      public void executeSubmit( String aP0_SessionItem ,
                                 String aP1_SessionData )
      {
         k2bsessionset objk2bsessionset;
         objk2bsessionset = new k2bsessionset();
         objk2bsessionset.AV8SessionItem = aP0_SessionItem;
         objk2bsessionset.AV9SessionData = aP1_SessionData;
         objk2bsessionset.context.SetSubmitInitialConfig(context);
         objk2bsessionset.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objk2bsessionset);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bsessionset)stateInfo).executePrivate();
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
         AV10Session.Set(AV8SessionItem, AV9SessionData);
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
         AV10Session = context.GetSession();
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private String AV8SessionItem ;
      private String AV9SessionData ;
      private IGxSession AV10Session ;
   }

}
