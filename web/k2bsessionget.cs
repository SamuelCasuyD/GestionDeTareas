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
   public class k2bsessionget : GXProcedure
   {
      public k2bsessionget( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public k2bsessionget( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( String aP0_SessionItem ,
                           out String aP1_SessionData )
      {
         this.AV10SessionItem = aP0_SessionItem;
         this.AV8SessionData = "" ;
         initialize();
         executePrivate();
         aP1_SessionData=this.AV8SessionData;
      }

      public String executeUdp( String aP0_SessionItem )
      {
         execute(aP0_SessionItem, out aP1_SessionData);
         return AV8SessionData ;
      }

      public void executeSubmit( String aP0_SessionItem ,
                                 out String aP1_SessionData )
      {
         k2bsessionget objk2bsessionget;
         objk2bsessionget = new k2bsessionget();
         objk2bsessionget.AV10SessionItem = aP0_SessionItem;
         objk2bsessionget.AV8SessionData = "" ;
         objk2bsessionget.context.SetSubmitInitialConfig(context);
         objk2bsessionget.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objk2bsessionget);
         aP1_SessionData=this.AV8SessionData;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bsessionget)stateInfo).executePrivate();
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
         AV8SessionData = AV9Session.Get(AV10SessionItem);
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
         AV9Session = context.GetSession();
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private String AV10SessionItem ;
      private String AV8SessionData ;
      private IGxSession AV9Session ;
      private String aP1_SessionData ;
   }

}
