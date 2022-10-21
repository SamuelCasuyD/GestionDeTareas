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
   public class k2bloadgridstate : GXProcedure
   {
      public k2bloadgridstate( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public k2bloadgridstate( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( String aP0_ProgramName ,
                           String aP1_SessionStateParameter ,
                           out SdtK2BGridState aP2_GridState )
      {
         this.AV9ProgramName = aP0_ProgramName;
         this.AV10SessionStateParameter = aP1_SessionStateParameter;
         this.AV8GridState = new SdtK2BGridState(context) ;
         initialize();
         executePrivate();
         aP2_GridState=this.AV8GridState;
      }

      public SdtK2BGridState executeUdp( String aP0_ProgramName ,
                                         String aP1_SessionStateParameter )
      {
         execute(aP0_ProgramName, aP1_SessionStateParameter, out aP2_GridState);
         return AV8GridState ;
      }

      public void executeSubmit( String aP0_ProgramName ,
                                 String aP1_SessionStateParameter ,
                                 out SdtK2BGridState aP2_GridState )
      {
         k2bloadgridstate objk2bloadgridstate;
         objk2bloadgridstate = new k2bloadgridstate();
         objk2bloadgridstate.AV9ProgramName = aP0_ProgramName;
         objk2bloadgridstate.AV10SessionStateParameter = aP1_SessionStateParameter;
         objk2bloadgridstate.AV8GridState = new SdtK2BGridState(context) ;
         objk2bloadgridstate.context.SetSubmitInitialConfig(context);
         objk2bloadgridstate.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objk2bloadgridstate);
         aP2_GridState=this.AV8GridState;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bloadgridstate)stateInfo).executePrivate();
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
         AV8GridState.FromXml(AV11Session.Get(AV9ProgramName+AV10SessionStateParameter+"GridState"), null, "K2BGridState", "TABLEROS_WEB");
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

      private String AV9ProgramName ;
      private String AV10SessionStateParameter ;
      private IGxSession AV11Session ;
      private SdtK2BGridState aP2_GridState ;
      private SdtK2BGridState AV8GridState ;
   }

}
