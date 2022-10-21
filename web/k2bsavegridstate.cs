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
   public class k2bsavegridstate : GXProcedure
   {
      public k2bsavegridstate( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public k2bsavegridstate( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( String aP0_ProgramName ,
                           String aP1_SessionStateParameter ,
                           SdtK2BGridState aP2_GridState )
      {
         this.AV10ProgramName = aP0_ProgramName;
         this.AV9SessionStateParameter = aP1_SessionStateParameter;
         this.AV8GridState = aP2_GridState;
         initialize();
         executePrivate();
      }

      public void executeSubmit( String aP0_ProgramName ,
                                 String aP1_SessionStateParameter ,
                                 SdtK2BGridState aP2_GridState )
      {
         k2bsavegridstate objk2bsavegridstate;
         objk2bsavegridstate = new k2bsavegridstate();
         objk2bsavegridstate.AV10ProgramName = aP0_ProgramName;
         objk2bsavegridstate.AV9SessionStateParameter = aP1_SessionStateParameter;
         objk2bsavegridstate.AV8GridState = aP2_GridState;
         objk2bsavegridstate.context.SetSubmitInitialConfig(context);
         objk2bsavegridstate.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objk2bsavegridstate);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bsavegridstate)stateInfo).executePrivate();
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
         AV11Session.Set(AV10ProgramName+AV9SessionStateParameter+"GridState", AV8GridState.ToXml(false, true, "K2BGridState", "TABLEROS_WEB"));
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
         AV11Session = context.GetSession();
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private String AV10ProgramName ;
      private String AV9SessionStateParameter ;
      private IGxSession AV11Session ;
      private SdtK2BGridState AV8GridState ;
   }

}
