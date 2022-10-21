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
   public class k2bisauthorizedactivitylist : GXProcedure
   {
      public k2bisauthorizedactivitylist( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public k2bisauthorizedactivitylist( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( ref GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> aP0_activityList )
      {
         this.AV9activityList = aP0_activityList;
         initialize();
         executePrivate();
         aP0_activityList=this.AV9activityList;
      }

      public GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> executeUdp( )
      {
         execute(ref aP0_activityList);
         return AV9activityList ;
      }

      public void executeSubmit( ref GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> aP0_activityList )
      {
         k2bisauthorizedactivitylist objk2bisauthorizedactivitylist;
         objk2bisauthorizedactivitylist = new k2bisauthorizedactivitylist();
         objk2bisauthorizedactivitylist.AV9activityList = aP0_activityList;
         objk2bisauthorizedactivitylist.context.SetSubmitInitialConfig(context);
         objk2bisauthorizedactivitylist.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objk2bisauthorizedactivitylist);
         aP0_activityList=this.AV9activityList;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bisauthorizedactivitylist)stateInfo).executePrivate();
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
         AV12GXV1 = 1;
         while ( AV12GXV1 <= AV9activityList.Count )
         {
            AV8activity = ((SdtK2BActivityList_K2BActivityListItem)AV9activityList.Item(AV12GXV1));
            AV8activity.gxTpr_Isauthorized = true;
            AV12GXV1 = (int)(AV12GXV1+1);
         }
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
         AV8activity = new SdtK2BActivityList_K2BActivityListItem(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV12GXV1 ;
      private GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> aP0_activityList ;
      private GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV9activityList ;
      private SdtK2BActivityList_K2BActivityListItem AV8activity ;
   }

}
