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
   public class k2bgetusermenu : GXProcedure
   {
      public k2bgetusermenu( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public k2bgetusermenu( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( out GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> aP0_MenuItems )
      {
         this.AV8MenuItems = new GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenuItem", "TABLEROS_WEB") ;
         initialize();
         executePrivate();
         aP0_MenuItems=this.AV8MenuItems;
      }

      public GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> executeUdp( )
      {
         execute(out aP0_MenuItems);
         return AV8MenuItems ;
      }

      public void executeSubmit( out GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> aP0_MenuItems )
      {
         k2bgetusermenu objk2bgetusermenu;
         objk2bgetusermenu = new k2bgetusermenu();
         objk2bgetusermenu.AV8MenuItems = new GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenuItem", "TABLEROS_WEB") ;
         objk2bgetusermenu.context.SetSubmitInitialConfig(context);
         objk2bgetusermenu.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objk2bgetusermenu);
         aP0_MenuItems=this.AV8MenuItems;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bgetusermenu)stateInfo).executePrivate();
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
         new k2blistprograms(context ).execute( out  AV9ListPrograms) ;
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem1 = AV8MenuItems;
         new k2blistprogramstomultilevelmenusdt(context ).execute(  AV9ListPrograms, out  GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem1) ;
         AV8MenuItems = GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem1;
         AV10SecurityMenu = new SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem(context);
         AV10SecurityMenu.gxTpr_Code = "Security";
         AV10SecurityMenu.gxTpr_Title = "Security";
         AV10SecurityMenu.gxTpr_Showinextrasmall = true;
         AV10SecurityMenu.gxTpr_Showinlarge = true;
         AV10SecurityMenu.gxTpr_Showinmedium = true;
         AV10SecurityMenu.gxTpr_Showinsmall = true;
         AV8MenuItems.Add(AV10SecurityMenu, 0);
         AV11SecurityItem = new SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem(context);
         AV11SecurityItem.gxTpr_Code = "ChangePassword";
         AV11SecurityItem.gxTpr_Title = "Change password";
         AV11SecurityItem.gxTpr_Link = "k2bchangepassword.aspx";
         AV11SecurityItem.gxTpr_Showinextrasmall = true;
         AV11SecurityItem.gxTpr_Showinlarge = true;
         AV11SecurityItem.gxTpr_Showinmedium = true;
         AV11SecurityItem.gxTpr_Showinsmall = true;
         AV10SecurityMenu.gxTpr_Items.Add(AV11SecurityItem, 0);
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
         AV9ListPrograms = new GXBaseCollection<SdtK2BProgramNames_ProgramName>( context, "ProgramName", "TABLEROS_WEB");
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem1 = new GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenuItem", "TABLEROS_WEB");
         AV10SecurityMenu = new SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem(context);
         AV11SecurityItem = new SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> aP0_MenuItems ;
      private GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> AV8MenuItems ;
      private GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem1 ;
      private GXBaseCollection<SdtK2BProgramNames_ProgramName> AV9ListPrograms ;
      private SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem AV10SecurityMenu ;
      private SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem AV11SecurityItem ;
   }

}
