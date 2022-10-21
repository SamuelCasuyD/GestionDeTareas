using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class k2bwwmasterpageorionhorizmenu : GXMasterPage, System.Web.SessionState.IRequiresSessionState
   {
      public k2bwwmasterpageorionhorizmenu( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public k2bwwmasterpageorionhorizmenu( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( )
      {
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            PA1B2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV21Pgmname = "K2BWWMasterPageOrionHorizMenu";
               context.Gx_err = 0;
               WS1B2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  WE1B2( ) ;
               }
            }
         }
         this.cleanup();
      }

      protected void RenderHtmlHeaders( )
      {
         if ( ! isFullAjaxMode( ) )
         {
            GXWebForm.AddResponsiveMetaHeaders((getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Meta);
            getDataAreaObject().RenderHtmlHeaders();
         }
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( ! isFullAjaxMode( ) )
         {
            getDataAreaObject().RenderHtmlOpenForm();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME_MPAGE", GetSecureSignedToken( "gxmpage_", StringUtil.RTrim( context.localUtil.Format( AV21Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", true, "vMENUITEMS_MPAGE", AV9MenuItems);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMENUITEMS_MPAGE", AV9MenuItems);
         }
         GxWebStd.gx_hidden_field( context, "vPGMNAME_MPAGE", StringUtil.RTrim( AV21Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME_MPAGE", GetSecureSignedToken( "gxmpage_", StringUtil.RTrim( context.localUtil.Format( AV21Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "MENUCONTAINER_MPAGE_Class", StringUtil.RTrim( divMenucontainer_Class));
         GxWebStd.gx_hidden_field( context, "MENUTOGGLE_MPAGE_Class", StringUtil.RTrim( bttMenutoggle_Class));
         GxWebStd.gx_hidden_field( context, "MYACCOUNTMENU_MPAGE_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divMyaccountmenu_Visible), 5, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm1B2( )
      {
         SendCloseFormHiddens( ) ;
         SendSecurityToken((String)(sPrefix));
         if ( ! isFullAjaxMode( ) )
         {
            getDataAreaObject().RenderHtmlCloseForm();
         }
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( ! ( WebComp_Notificationscomponent == null ) )
         {
            WebComp_Notificationscomponent.componentjscripts();
         }
         context.AddJavascriptSource("K2BHorizontalMenu/K2BHorizontalMenuRender.js", "", false, true);
         context.AddJavascriptSource("K2BAccordionMenu/metisMenu-master/dist/metisMenu.min.js", "", false, true);
         context.AddJavascriptSource("K2BAccordionMenu/K2BAccordionMenuRender.js", "", false, true);
         context.AddJavascriptSource("k2bwwmasterpageorionhorizmenu.js", "?20221020218575", false, true);
         context.WriteHtmlTextNl( "</body>") ;
         context.WriteHtmlTextNl( "</html>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
      }

      public override String GetPgmname( )
      {
         return "K2BWWMasterPageOrionHorizMenu" ;
      }

      public override String GetPgmdesc( )
      {
         return "Horizontal-Top menu" ;
      }

      protected void WB1B0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            RenderHtmlHeaders( ) ;
            RenderHtmlOpenForm( ) ;
            if ( ! ShowMPWhenPopUp( ) && context.isPopUpObject( ) )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableOutput();
               }
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
               /* Content placeholder */
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gx-content-placeholder");
               context.WriteHtmlText( ">") ;
               if ( ! isFullAjaxMode( ) )
               {
                  getDataAreaObject().RenderHtmlContent();
               }
               context.WriteHtmlText( "</div>") ;
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
               wbLoad = true;
               return  ;
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "MainContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divHeader_Internalname, 1, 0, "px", 0, "px", "ContainerFluid K2BHeader", "left", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BT_AreaStart", "left", "Middle", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTopstart_Internalname, 1, 0, "px", 0, "px", "K2BT_HeaderArea", "left", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BT_HeaderItem", "left", "top", "", "flex-grow:1;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 10,'',true,'',0)\"";
            ClassString = bttMenutoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttMenutoggle_Internalname, "", "|||", bttMenutoggle_Jsonclick, 7, "", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",true,"+"'"+"e111b1_client"+"'", TempTags, "", 2, "HLP_K2BWWMasterPageOrionHorizMenu.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BT_HeaderItem", "left", "top", "", "flex-grow:1;", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 12,'',true,'',0)\"";
            ClassString = "Image_HeaderLogo";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "bb4462ea-0eb3-44b4-8320-f971481f81b4", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgApplicationicon_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgApplicationicon_Jsonclick, "'"+""+"'"+",true,"+"'"+"e121b1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BWWMasterPageOrionHorizMenu.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BT_HeaderItem K2BT_AlignBottom", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblApplicationname_Internalname, "Application name", "", "", lblApplicationname_Jsonclick, "'"+""+"'"+",true,"+"'"+"e131b1_client"+"'", "", "K2BT_ApplicationName", 7, "", 1, 1, 0, "HLP_K2BWWMasterPageOrionHorizMenu.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "Middle", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BT_AreaCenter", "Center", "Middle", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTopmiddle_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* User Defined Control */
            ucK2bhorizontalmenu.SetProperty("MenuItems", AV9MenuItems);
            ucK2bhorizontalmenu.Render(context, "k2bhorizontalmenu", K2bhorizontalmenu_Internalname, "K2BHORIZONTALMENU_MPAGEContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "Middle", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BT_AreaEnd", "Right", "Middle", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTopend_Internalname, 1, 0, "px", 0, "px", "K2BT_HeaderArea", "left", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpMPW0022"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( ! context.isAjaxRequest( ) )
               {
                  context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpMPW0022"+"");
               }
               WebComp_Notificationscomponent.componentdraw();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUniversalsearch_Internalname, divUniversalsearch_Visible, 0, "px", 0, "px", divUniversalsearch_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSearchcriteria_Internalname, "Search Criteria", "gx-form-item K2BTools_SearchCriteriaLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',true,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSearchcriteria_Internalname, StringUtil.RTrim( AV13SearchCriteria), StringUtil.RTrim( context.localUtil.Format( AV13SearchCriteria, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",true,"+"'"+"E_MPAGE."+"'", "", "", "", "Search", edtavSearchcriteria_Jsonclick, 0, "K2BTools_SearchCriteria", "", "", "", "", 1, edtavSearchcriteria_Enabled, 0, "text", "", 26, "chr", 1, "row", 150, 0, 0, 0, 1, -1, -1, true, "K2BSearchCriteria", "left", true, "", "HLP_K2BWWMasterPageOrionHorizMenu.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',true,'',0)\"";
            ClassString = "K2BToolsButton_Search";
            StyleString = "";
            sImgUrl = (String)(context.GetImagePath( "b2f44a32-cd24-4170-a5da-849c2e18a0bd", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgImage2_Jsonclick, "'"+""+"'"+",true,"+"'"+"e141b1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BWWMasterPageOrionHorizMenu.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMyaccount_Internalname, 1, 0, "px", 0, "px", "K2BToolsSection_MyAccountHeader", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblUsernametextblock_Internalname, lblUsernametextblock_Caption, "", "", lblUsernametextblock_Jsonclick, "'"+""+"'"+",true,"+"'"+"e151b1_client"+"'", "", "K2BToolsTextBlock_MyAccount", 7, "", 1, 1, 0, "HLP_K2BWWMasterPageOrionHorizMenu.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblUserinitialstextblocksmall_Internalname, lblUserinitialstextblocksmall_Caption, "", "", lblUserinitialstextblocksmall_Jsonclick, "'"+""+"'"+",true,"+"'"+"e151b1_client"+"'", "", "K2BToolsTextblock_InitialsCircleSmall", 7, "", lblUserinitialstextblocksmall_Visible, 1, 0, "HLP_K2BWWMasterPageOrionHorizMenu.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", "User Avatar Small", "gx-form-item K2BToolsImage_RoundPhotoSmallLabel", 0, true, "width: 25%;");
            /* Active Bitmap Variable */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',true,'',0)\"";
            ClassString = "K2BToolsImage_RoundPhotoSmall";
            StyleString = "";
            AV18UserAvatarSmall_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV18UserAvatarSmall))&&String.IsNullOrEmpty(StringUtil.RTrim( AV22Useravatarsmall_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV18UserAvatarSmall)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV18UserAvatarSmall)) ? AV22Useravatarsmall_GXI : context.PathToRelativeUrl( AV18UserAvatarSmall));
            GxWebStd.gx_bitmap( context, imgavUseravatarsmall_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgavUseravatarsmall_Visible, 1, "", "", 0, -1, 0, "", 0, "", 0, 0, 7, imgavUseravatarsmall_Jsonclick, "'"+""+"'"+",true,"+"'"+"e151b1_client"+"'", StyleString, ClassString, "", "", "", "", ""+TempTags, "", "", 1, AV18UserAvatarSmall_IsBlob, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BWWMasterPageOrionHorizMenu.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "Right", "Middle", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMiddle_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BT_AreaStart", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCenterstart_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "PromptAdvancedBarCellCompact", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMenucontainer_Internalname, 1, 0, "px", 0, "px", divMenucontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucK2baccordionmenu.SetProperty("MenuItems", AV9MenuItems);
            ucK2baccordionmenu.Render(context, "k2baccordionmenu", K2baccordionmenu_Internalname, "K2BACCORDIONMENU_MPAGEContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BT_AreaCenter K2BT_100x100", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCentermiddle_Internalname, 1, 0, "px", 0, "px", "BodyContainer", "left", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BT_100x100", "left", "top", "", "flex-grow:1;", "div");
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            /* Content placeholder */
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-content-placeholder");
            context.WriteHtmlText( ">") ;
            if ( ! isFullAjaxMode( ) )
            {
               getDataAreaObject().RenderHtmlContent();
            }
            context.WriteHtmlText( "</div>") ;
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "K2BT_AreaEnd", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCenterend_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMyaccountmenu_Internalname, divMyaccountmenu_Visible, 0, "px", 0, "px", "K2BToolsMyAccountTable", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divSection1_Internalname, 1, 0, "px", 0, "px", "K2BT_UserInfoSection", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", "User Avatar", "gx-form-item K2BToolsImage_RoundPhotoLabel", 0, true, "width: 25%;");
            /* Static Bitmap Variable */
            ClassString = "K2BToolsImage_RoundPhoto";
            StyleString = "";
            AV17UserAvatar_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV17UserAvatar))&&String.IsNullOrEmpty(StringUtil.RTrim( AV23Useravatar_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV17UserAvatar)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV17UserAvatar)) ? AV23Useravatar_GXI : context.PathToRelativeUrl( AV17UserAvatar));
            GxWebStd.gx_bitmap( context, imgavUseravatar_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgavUseravatar_Visible, 0, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, AV17UserAvatar_IsBlob, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BWWMasterPageOrionHorizMenu.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblUserinitialstextblock_Internalname, lblUserinitialstextblock_Caption, "", "", lblUserinitialstextblock_Jsonclick, "'"+""+"'"+",true,"+"'"+"E_MPAGE."+"'", "", "K2BToolsTextblock_InitialsCircle", 0, "", lblUserinitialstextblock_Visible, 1, 0, "HLP_K2BWWMasterPageOrionHorizMenu.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblUsername_Internalname, lblUsername_Caption, "", "", lblUsername_Jsonclick, "'"+""+"'"+",true,"+"'"+"E_MPAGE."+"'", "", "K2BToolsTextblock_UserName", 0, "", 1, 1, 0, "HLP_K2BWWMasterPageOrionHorizMenu.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblUseremail_Internalname, lblUseremail_Caption, "", "", lblUseremail_Jsonclick, "'"+""+"'"+",true,"+"'"+"E_MPAGE."+"'", "", "K2BToolsTextblock_UserEmail", 0, "", 1, 1, 0, "HLP_K2BWWMasterPageOrionHorizMenu.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblChangepassword_Internalname, "Change Password", "", "", lblChangepassword_Jsonclick, "'"+""+"'"+",true,"+"'"+"e161b1_client"+"'", "", "K2BToolsTextBlock_ChangePassword", 7, "", 1, 1, 0, "HLP_K2BWWMasterPageOrionHorizMenu.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSignout_Internalname, "Sign Out", "", "", lblSignout_Jsonclick, "'"+""+"'"+",true,"+"'"+"ESIGNOUT_MPAGE."+"'", "", "K2BToolsTextBlock_Logout", 5, "", 1, 1, 0, "HLP_K2BWWMasterPageOrionHorizMenu.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START1B2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP1B0( ) ;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( getDataAreaObject().ExecuteStartEvent() != 0 )
            {
               setAjaxCallMode();
            }
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      protected void WS1B2( )
      {
         START1B2( ) ;
         EVT1B2( ) ;
      }

      protected void EVT1B2( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               sEvt = cgiGet( "_EventName");
               EvtGridId = cgiGet( "_EventGridId");
               EvtRowId = cgiGet( "_EventRowId");
               if ( StringUtil.Len( sEvt) > 0 )
               {
                  sEvtType = StringUtil.Left( sEvt, 1);
                  sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                  if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, 1);
                     if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                     {
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                        if ( StringUtil.StrCmp(sEvt, "RFR_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "START_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E171B2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "REFRESH_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Refresh */
                           E181B2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "SIGNOUT_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: 'SignOut' */
                           E191B2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LOAD_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Load */
                           E201B2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! wbErr )
                           {
                              Rfr0gs = false;
                              if ( ! Rfr0gs )
                              {
                              }
                              dynload_actions( ) ;
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           dynload_actions( ) ;
                        }
                     }
                     else
                     {
                     }
                  }
                  else if ( StringUtil.StrCmp(sEvtType, "M") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-2));
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-6));
                     nCmpId = (short)(NumberUtil.Val( sEvtType, "."));
                     if ( nCmpId == 22 )
                     {
                        WebComp_Notificationscomponent = getWebComponent(GetType(), "GeneXus.Programs", "k2bt_notificationsviewer", new Object[] {context} );
                        WebComp_Notificationscomponent.ComponentInit();
                        WebComp_Notificationscomponent.Name = "K2BT_NotificationsViewer";
                        WebComp_Notificationscomponent_Component = "K2BT_NotificationsViewer";
                        WebComp_Notificationscomponent.componentprocess("MPW0022", "", sEvt);
                     }
                  }
                  if ( context.wbHandled == 0 )
                  {
                     getDataAreaObject().DispatchEvents();
                  }
                  context.wbHandled = 1;
               }
            }
         }
      }

      protected void WE1B2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm1B2( ) ;
            }
         }
      }

      protected void PA1B2( )
      {
         if ( nDonePA == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", 0);
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            init_web_controls( ) ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavSearchcriteria_Internalname;
               AssignAttri("", true, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF1B2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV21Pgmname = "K2BWWMasterPageOrionHorizMenu";
         context.Gx_err = 0;
      }

      protected void RF1B2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( ShowMPWhenPopUp( ) || ! context.isPopUpObject( ) )
         {
            /* Execute user event: Refresh */
            E181B2 ();
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
            {
               if ( StringUtil.StrCmp(WebComp_Notificationscomponent_Component, "") == 0 )
               {
                  WebComp_Notificationscomponent = getWebComponent(GetType(), "GeneXus.Programs", "k2bt_notificationsviewer", new Object[] {context} );
                  WebComp_Notificationscomponent.ComponentInit();
                  WebComp_Notificationscomponent.Name = "K2BT_NotificationsViewer";
                  WebComp_Notificationscomponent_Component = "K2BT_NotificationsViewer";
               }
               WebComp_Notificationscomponent.setjustcreated();
               WebComp_Notificationscomponent.componentprepare(new Object[] {(String)"MPW0022",(String)""});
               WebComp_Notificationscomponent.componentbind(new Object[] {});
               if ( isFullAjaxMode( ) )
               {
                  context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpMPW0022"+"");
                  WebComp_Notificationscomponent.componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
               if ( 1 != 0 )
               {
                  WebComp_Notificationscomponent.componentstart();
               }
            }
            gxdyncontrolsrefreshing = true;
            fix_multi_value_controls( ) ;
            gxdyncontrolsrefreshing = false;
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E201B2 ();
            WB1B0( ) ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
      }

      protected void send_integrity_lvl_hashes1B2( )
      {
      }

      protected void before_start_formulas( )
      {
         AV21Pgmname = "K2BWWMasterPageOrionHorizMenu";
         context.Gx_err = 0;
      }

      protected void STRUP1B0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E171B2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMENUITEMS_MPAGE"), AV9MenuItems);
            /* Read saved values. */
            /* Read variables values. */
            AV13SearchCriteria = cgiGet( edtavSearchcriteria_Internalname);
            AssignAttri("", true, "AV13SearchCriteria", AV13SearchCriteria);
            AV18UserAvatarSmall = cgiGet( imgavUseravatarsmall_Internalname);
            AV17UserAvatar = cgiGet( imgavUseravatar_Internalname);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E171B2 ();
         if (returnInSub) return;
      }

      protected void E171B2( )
      {
         /* Start Routine */
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Meta.addItem("viewport", "width=device-width; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;", 0) ;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Meta.addItem("apple-mobile-web-app-capable", "yes", 0) ;
         divMyaccountmenu_Visible = 0;
         AssignProp("", true, divMyaccountmenu_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divMyaccountmenu_Visible), 5, 0), true);
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem1 = AV9MenuItems;
         new k2bgetusermenu(context ).execute( out  GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem1) ;
         AV9MenuItems = GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem1;
         GXt_objcol_SdtSearchableTransactions_SearchableTransactionsItem2 = AV12SearchableTransactions;
         new k2bgetsearchableentities(context ).execute( out  GXt_objcol_SdtSearchableTransactions_SearchableTransactionsItem2) ;
         AV12SearchableTransactions = GXt_objcol_SdtSearchableTransactions_SearchableTransactionsItem2;
         if ( new k2bisauthorizedactivityname(context).executeUdp(  "",  "",  "None",  "K2BToolsSearchResult",  AV21Pgmname) && ( AV12SearchableTransactions.Count > 0 ) )
         {
            GXt_char3 = AV14SearchCriteriaSession;
            new k2bsessionget(context ).execute(  AV21Pgmname+"-SearchCriteria", out  GXt_char3) ;
            AV14SearchCriteriaSession = GXt_char3;
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14SearchCriteriaSession)) )
            {
               AV13SearchCriteria = AV14SearchCriteriaSession;
               AssignAttri("", true, "AV13SearchCriteria", AV13SearchCriteria);
            }
         }
         else
         {
            divUniversalsearch_Visible = 0;
            AssignProp("", true, divUniversalsearch_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divUniversalsearch_Visible), 5, 0), true);
            divUniversalsearch_Class = "K2BToolsTable_Invisible";
            AssignProp("", true, divUniversalsearch_Internalname, "Class", divUniversalsearch_Class, true);
         }
         GXt_char3 = AV15UserCaption;
         new k2bgetusercaption(context ).execute( out  GXt_char3) ;
         AV15UserCaption = GXt_char3;
         GXt_char3 = AV17UserAvatar;
         new k2bgetuseravatar(context ).execute( out  GXt_char3) ;
         AV17UserAvatar = GXt_char3;
         AssignProp("", true, imgavUseravatar_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV17UserAvatar)) ? AV23Useravatar_GXI : context.convertURL( context.PathToRelativeUrl( AV17UserAvatar))), true);
         AssignProp("", true, imgavUseravatar_Internalname, "SrcSet", context.GetImageSrcSet( AV17UserAvatar), true);
         AV18UserAvatarSmall = AV17UserAvatar;
         AssignProp("", true, imgavUseravatarsmall_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV18UserAvatarSmall)) ? AV22Useravatarsmall_GXI : context.convertURL( context.PathToRelativeUrl( AV18UserAvatarSmall))), true);
         AssignProp("", true, imgavUseravatarsmall_Internalname, "SrcSet", context.GetImageSrcSet( AV18UserAvatarSmall), true);
         AV22Useravatarsmall_GXI = AV23Useravatar_GXI;
         AssignProp("", true, imgavUseravatarsmall_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV18UserAvatarSmall)) ? AV22Useravatarsmall_GXI : context.convertURL( context.PathToRelativeUrl( AV18UserAvatarSmall))), true);
         AssignProp("", true, imgavUseravatarsmall_Internalname, "SrcSet", context.GetImageSrcSet( AV18UserAvatarSmall), true);
         GXt_char3 = "";
         new k2bgetuseremail(context ).execute( out  GXt_char3) ;
         lblUseremail_Caption = GXt_char3;
         AssignProp("", true, lblUseremail_Internalname, "Caption", lblUseremail_Caption, true);
         lblUsername_Caption = AV15UserCaption;
         AssignProp("", true, lblUsername_Internalname, "Caption", lblUsername_Caption, true);
         lblUsernametextblock_Caption = AV15UserCaption;
         AssignProp("", true, lblUsernametextblock_Internalname, "Caption", lblUsernametextblock_Caption, true);
         lblUserinitialstextblock_Caption = "";
         AssignProp("", true, lblUserinitialstextblock_Internalname, "Caption", lblUserinitialstextblock_Caption, true);
         lblUserinitialstextblocksmall_Caption = "";
         AssignProp("", true, lblUserinitialstextblocksmall_Internalname, "Caption", lblUserinitialstextblocksmall_Caption, true);
         AV25GXV2 = 1;
         AV24GXV1 = GxRegex.Split(AV15UserCaption," ");
         while ( AV25GXV2 <= AV24GXV1.Count )
         {
            AV16Name = AV24GXV1.GetString(AV25GXV2);
            lblUserinitialstextblock_Caption = lblUserinitialstextblock_Caption+StringUtil.Upper( StringUtil.Substring( AV16Name, 1, 1));
            AssignProp("", true, lblUserinitialstextblock_Internalname, "Caption", lblUserinitialstextblock_Caption, true);
            lblUserinitialstextblocksmall_Caption = lblUserinitialstextblocksmall_Caption+StringUtil.Upper( StringUtil.Substring( AV16Name, 1, 1));
            AssignProp("", true, lblUserinitialstextblocksmall_Internalname, "Caption", lblUserinitialstextblocksmall_Caption, true);
            if ( StringUtil.Len( lblUserinitialstextblock_Caption) == 2 )
            {
               if (true) break;
            }
            AV25GXV2 = (int)(AV25GXV2+1);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV17UserAvatar)) && String.IsNullOrEmpty(StringUtil.RTrim( AV23Useravatar_GXI)) )
         {
            lblUserinitialstextblock_Visible = 1;
            AssignProp("", true, lblUserinitialstextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblUserinitialstextblock_Visible), 5, 0), true);
            lblUserinitialstextblocksmall_Visible = 1;
            AssignProp("", true, lblUserinitialstextblocksmall_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblUserinitialstextblocksmall_Visible), 5, 0), true);
            imgavUseravatar_Visible = 0;
            AssignProp("", true, imgavUseravatar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgavUseravatar_Visible), 5, 0), true);
            imgavUseravatarsmall_Visible = 0;
            AssignProp("", true, imgavUseravatarsmall_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgavUseravatarsmall_Visible), 5, 0), true);
         }
         else
         {
            lblUserinitialstextblock_Visible = 0;
            AssignProp("", true, lblUserinitialstextblock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblUserinitialstextblock_Visible), 5, 0), true);
            lblUserinitialstextblocksmall_Visible = 0;
            AssignProp("", true, lblUserinitialstextblocksmall_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblUserinitialstextblocksmall_Visible), 5, 0), true);
            imgavUseravatar_Visible = 1;
            AssignProp("", true, imgavUseravatar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgavUseravatar_Visible), 5, 0), true);
            imgavUseravatarsmall_Visible = 1;
            AssignProp("", true, imgavUseravatarsmall_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgavUseravatarsmall_Visible), 5, 0), true);
         }
      }

      protected void E181B2( )
      {
         /* Refresh Routine */
         if ( ! new k2bisauthenticated(context).executeUdp( ) )
         {
            CallWebObject(formatLink("k2bnotauthorized.aspx") + "?" + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.RTrim("None")) + "," + UrlEncode(StringUtil.RTrim("")) + "," + UrlEncode(StringUtil.RTrim("")));
            context.wjLocDisableFrm = 1;
         }
         GXt_char3 = AV14SearchCriteriaSession;
         new k2bsessionget(context ).execute(  AV21Pgmname+"-SearchCriteria", out  GXt_char3) ;
         AV14SearchCriteriaSession = GXt_char3;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14SearchCriteriaSession)) )
         {
            AV13SearchCriteria = AV14SearchCriteriaSession;
            AssignAttri("", true, "AV13SearchCriteria", AV13SearchCriteria);
         }
         /*  Sending Event outputs  */
      }

      protected void E191B2( )
      {
         /* 'SignOut' Routine */
         new k2blogoutimplementation(context ).execute( ) ;
      }

      protected void nextLoad( )
      {
      }

      protected void E201B2( )
      {
         /* Load Routine */
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
      }

      public override String getresponse( String sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA1B2( ) ;
         WS1B2( ) ;
         WE1B2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( String sGXDynURL )
      {
      }

      public override void master_styles( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("Shared/fontawesome-free-5.1.1-web/css/all.css", "");
         AddStyleSheetFile("Shared/fontawesome-free-5.1.1-web/css/all.css", "");
         AddStyleSheetFile("K2BHorizontalMenu/css/K2BHorizontalMenu.css", "");
         AddStyleSheetFile("K2BAccordionMenu/metisMenu-master/dist/metisMenu.min.css", "");
         AddStyleSheetFile("K2BAccordionMenu/k2btoolsresources/metisFolder.css", "");
         AddStyleSheetFile("K2BAccordionMenu/k2btoolsresources/defaultTheme.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( StringUtil.StrCmp(WebComp_Notificationscomponent_Component, "") == 0 )
         {
            WebComp_Notificationscomponent = getWebComponent(GetType(), "GeneXus.Programs", "k2bt_notificationsviewer", new Object[] {context} );
            WebComp_Notificationscomponent.ComponentInit();
            WebComp_Notificationscomponent.Name = "K2BT_NotificationsViewer";
            WebComp_Notificationscomponent_Component = "K2BT_NotificationsViewer";
         }
         if ( ! ( WebComp_Notificationscomponent == null ) )
         {
            WebComp_Notificationscomponent.componentthemes();
         }
         bool outputEnabled = isOutputEnabled( ) ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((String)(getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Item(idxLst))), "?202210202185735", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("k2bwwmasterpageorionhorizmenu.js", "?202210202185736", false, true);
         context.AddJavascriptSource("K2BHorizontalMenu/K2BHorizontalMenuRender.js", "", false, true);
         context.AddJavascriptSource("K2BAccordionMenu/metisMenu-master/dist/metisMenu.min.js", "", false, true);
         context.AddJavascriptSource("K2BAccordionMenu/K2BAccordionMenuRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         bttMenutoggle_Internalname = "MENUTOGGLE_MPAGE";
         imgApplicationicon_Internalname = "APPLICATIONICON_MPAGE";
         lblApplicationname_Internalname = "APPLICATIONNAME_MPAGE";
         divTopstart_Internalname = "TOPSTART_MPAGE";
         K2bhorizontalmenu_Internalname = "K2BHORIZONTALMENU_MPAGE";
         divTopmiddle_Internalname = "TOPMIDDLE_MPAGE";
         edtavSearchcriteria_Internalname = "vSEARCHCRITERIA_MPAGE";
         imgImage2_Internalname = "IMAGE2_MPAGE";
         divUniversalsearch_Internalname = "UNIVERSALSEARCH_MPAGE";
         lblUsernametextblock_Internalname = "USERNAMETEXTBLOCK_MPAGE";
         lblUserinitialstextblocksmall_Internalname = "USERINITIALSTEXTBLOCKSMALL_MPAGE";
         imgavUseravatarsmall_Internalname = "vUSERAVATARSMALL_MPAGE";
         divMyaccount_Internalname = "MYACCOUNT_MPAGE";
         divTopend_Internalname = "TOPEND_MPAGE";
         divHeader_Internalname = "HEADER_MPAGE";
         K2baccordionmenu_Internalname = "K2BACCORDIONMENU_MPAGE";
         divMenucontainer_Internalname = "MENUCONTAINER_MPAGE";
         divCenterstart_Internalname = "CENTERSTART_MPAGE";
         divCentermiddle_Internalname = "CENTERMIDDLE_MPAGE";
         imgavUseravatar_Internalname = "vUSERAVATAR_MPAGE";
         lblUserinitialstextblock_Internalname = "USERINITIALSTEXTBLOCK_MPAGE";
         lblUsername_Internalname = "USERNAME_MPAGE";
         lblUseremail_Internalname = "USEREMAIL_MPAGE";
         divSection1_Internalname = "SECTION1_MPAGE";
         lblChangepassword_Internalname = "CHANGEPASSWORD_MPAGE";
         lblSignout_Internalname = "SIGNOUT_MPAGE";
         divMyaccountmenu_Internalname = "MYACCOUNTMENU_MPAGE";
         divCenterend_Internalname = "CENTEREND_MPAGE";
         divMiddle_Internalname = "MIDDLE_MPAGE";
         divMaintable_Internalname = "MAINTABLE_MPAGE";
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Internalname = "FORM_MPAGE";
      }

      public override void initialize_properties( )
      {
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         lblUseremail_Caption = "test@test.com";
         lblUsername_Caption = "User Name";
         lblUserinitialstextblock_Caption = "Initials";
         lblUserinitialstextblock_Visible = 1;
         imgavUseravatar_Visible = 1;
         divMyaccountmenu_Visible = 1;
         imgavUseravatarsmall_Jsonclick = "";
         imgavUseravatarsmall_Visible = 1;
         lblUserinitialstextblocksmall_Caption = "Initials";
         lblUserinitialstextblocksmall_Visible = 1;
         lblUsernametextblock_Caption = "John Doe";
         edtavSearchcriteria_Jsonclick = "";
         edtavSearchcriteria_Enabled = 1;
         divUniversalsearch_Class = "K2BToolsTable_SearchContainer";
         divUniversalsearch_Visible = 1;
         bttMenutoggle_Class = "K2BToolsButton_BtnToggle InvisibleInSmallButton InvisibleInMediumButton InvisibleInLargeButton";
         divMenucontainer_Class = "K2BToolsMenuContainerInvisibleCompact";
         Contholder1.setDataArea(getDataAreaObject());
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH_MPAGE","{handler:'Refresh',iparms:[{av:'AV21Pgmname',fld:'vPGMNAME_MPAGE',pic:'',hsh:true}]");
         setEventMetadata("REFRESH_MPAGE",",oparms:[{av:'AV13SearchCriteria',fld:'vSEARCHCRITERIA_MPAGE',pic:''}]}");
         setEventMetadata("DOSEARCH_MPAGE","{handler:'E141B1',iparms:[{av:'AV13SearchCriteria',fld:'vSEARCHCRITERIA_MPAGE',pic:''}]");
         setEventMetadata("DOSEARCH_MPAGE",",oparms:[{av:'AV13SearchCriteria',fld:'vSEARCHCRITERIA_MPAGE',pic:''}]}");
         setEventMetadata("TOGGLEMENU_MPAGE","{handler:'E111B1',iparms:[{av:'divMenucontainer_Class',ctrl:'MENUCONTAINER_MPAGE',prop:'Class'},{ctrl:'MENUTOGGLE_MPAGE',prop:'Class'}]");
         setEventMetadata("TOGGLEMENU_MPAGE",",oparms:[{av:'divMenucontainer_Class',ctrl:'MENUCONTAINER_MPAGE',prop:'Class'},{ctrl:'MENUTOGGLE_MPAGE',prop:'Class'}]}");
         setEventMetadata("OPENTABLE_MPAGE","{handler:'E151B1',iparms:[{av:'divMyaccountmenu_Visible',ctrl:'MYACCOUNTMENU_MPAGE',prop:'Visible'}]");
         setEventMetadata("OPENTABLE_MPAGE",",oparms:[{av:'divMyaccountmenu_Visible',ctrl:'MYACCOUNTMENU_MPAGE',prop:'Visible'}]}");
         setEventMetadata("CHANGEPASSWORD_MPAGE","{handler:'E161B1',iparms:[]");
         setEventMetadata("CHANGEPASSWORD_MPAGE",",oparms:[]}");
         setEventMetadata("SIGNOUT_MPAGE","{handler:'E191B2',iparms:[]");
         setEventMetadata("SIGNOUT_MPAGE",",oparms:[]}");
         setEventMetadata("APPLICATIONICON_MPAGE.CLICK_MPAGE","{handler:'E121B1',iparms:[]");
         setEventMetadata("APPLICATIONICON_MPAGE.CLICK_MPAGE",",oparms:[]}");
         setEventMetadata("APPLICATIONNAME_MPAGE.CLICK_MPAGE","{handler:'E131B1',iparms:[]");
         setEventMetadata("APPLICATIONNAME_MPAGE.CLICK_MPAGE",",oparms:[]}");
         return  ;
      }

      public override void cleanup( )
      {
         flushBuffer();
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections() ;
         }
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         Contholder1 = new GXDataAreaControl();
         AV21Pgmname = "";
         GXKey = "";
         AV9MenuItems = new GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenuItem", "TABLEROS_WEB");
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttMenutoggle_Jsonclick = "";
         sImgUrl = "";
         imgApplicationicon_Jsonclick = "";
         lblApplicationname_Jsonclick = "";
         ucK2bhorizontalmenu = new GXUserControl();
         AV13SearchCriteria = "";
         imgImage2_Jsonclick = "";
         lblUsernametextblock_Jsonclick = "";
         lblUserinitialstextblocksmall_Jsonclick = "";
         AV18UserAvatarSmall = "";
         AV22Useravatarsmall_GXI = "";
         ucK2baccordionmenu = new GXUserControl();
         AV17UserAvatar = "";
         AV23Useravatar_GXI = "";
         lblUserinitialstextblock_Jsonclick = "";
         lblUsername_Jsonclick = "";
         lblUseremail_Jsonclick = "";
         lblChangepassword_Jsonclick = "";
         lblSignout_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         WebComp_Notificationscomponent_Component = "";
         GX_FocusControl = "";
         GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem1 = new GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenuItem", "TABLEROS_WEB");
         AV12SearchableTransactions = new GXBaseCollection<SdtSearchableTransactions_SearchableTransactionsItem>( context, "SearchableTransactionsItem", "TABLEROS_WEB");
         GXt_objcol_SdtSearchableTransactions_SearchableTransactionsItem2 = new GXBaseCollection<SdtSearchableTransactions_SearchableTransactionsItem>( context, "SearchableTransactionsItem", "TABLEROS_WEB");
         AV14SearchCriteriaSession = "";
         AV15UserCaption = "";
         AV24GXV1 = new GxSimpleCollection<String>();
         AV16Name = "";
         GXt_char3 = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sDynURL = "";
         Form = new GXWebForm();
         WebComp_Notificationscomponent = new GeneXus.Http.GXNullWebComponent();
         AV21Pgmname = "K2BWWMasterPageOrionHorizMenu";
         /* GeneXus formulas. */
         AV21Pgmname = "K2BWWMasterPageOrionHorizMenu";
         context.Gx_err = 0;
      }

      private short initialized ;
      private short GxWebError ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGotPars ;
      private short nGXWrapped ;
      private int divMyaccountmenu_Visible ;
      private int divUniversalsearch_Visible ;
      private int edtavSearchcriteria_Enabled ;
      private int lblUserinitialstextblocksmall_Visible ;
      private int imgavUseravatarsmall_Visible ;
      private int imgavUseravatar_Visible ;
      private int lblUserinitialstextblock_Visible ;
      private int AV25GXV2 ;
      private int idxLst ;
      private String divMenucontainer_Class ;
      private String bttMenutoggle_Class ;
      private String AV21Pgmname ;
      private String GXKey ;
      private String sPrefix ;
      private String divMaintable_Internalname ;
      private String divHeader_Internalname ;
      private String divTopstart_Internalname ;
      private String TempTags ;
      private String ClassString ;
      private String StyleString ;
      private String bttMenutoggle_Internalname ;
      private String bttMenutoggle_Jsonclick ;
      private String sImgUrl ;
      private String imgApplicationicon_Internalname ;
      private String imgApplicationicon_Jsonclick ;
      private String lblApplicationname_Internalname ;
      private String lblApplicationname_Jsonclick ;
      private String divTopmiddle_Internalname ;
      private String K2bhorizontalmenu_Internalname ;
      private String divTopend_Internalname ;
      private String divUniversalsearch_Internalname ;
      private String divUniversalsearch_Class ;
      private String edtavSearchcriteria_Internalname ;
      private String AV13SearchCriteria ;
      private String edtavSearchcriteria_Jsonclick ;
      private String imgImage2_Internalname ;
      private String imgImage2_Jsonclick ;
      private String divMyaccount_Internalname ;
      private String lblUsernametextblock_Internalname ;
      private String lblUsernametextblock_Caption ;
      private String lblUsernametextblock_Jsonclick ;
      private String lblUserinitialstextblocksmall_Internalname ;
      private String lblUserinitialstextblocksmall_Caption ;
      private String lblUserinitialstextblocksmall_Jsonclick ;
      private String imgavUseravatarsmall_Internalname ;
      private String imgavUseravatarsmall_Jsonclick ;
      private String divMiddle_Internalname ;
      private String divCenterstart_Internalname ;
      private String divMenucontainer_Internalname ;
      private String K2baccordionmenu_Internalname ;
      private String divCentermiddle_Internalname ;
      private String divCenterend_Internalname ;
      private String divMyaccountmenu_Internalname ;
      private String divSection1_Internalname ;
      private String imgavUseravatar_Internalname ;
      private String lblUserinitialstextblock_Internalname ;
      private String lblUserinitialstextblock_Caption ;
      private String lblUserinitialstextblock_Jsonclick ;
      private String lblUsername_Internalname ;
      private String lblUsername_Caption ;
      private String lblUsername_Jsonclick ;
      private String lblUseremail_Internalname ;
      private String lblUseremail_Caption ;
      private String lblUseremail_Jsonclick ;
      private String lblChangepassword_Internalname ;
      private String lblChangepassword_Jsonclick ;
      private String lblSignout_Internalname ;
      private String lblSignout_Jsonclick ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String WebComp_Notificationscomponent_Component ;
      private String GX_FocusControl ;
      private String AV14SearchCriteriaSession ;
      private String AV15UserCaption ;
      private String AV16Name ;
      private String GXt_char3 ;
      private String sDynURL ;
      private bool wbLoad ;
      private bool AV18UserAvatarSmall_IsBlob ;
      private bool AV17UserAvatar_IsBlob ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool toggleJsOutput ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private String AV22Useravatarsmall_GXI ;
      private String AV23Useravatar_GXI ;
      private String AV18UserAvatarSmall ;
      private String AV17UserAvatar ;
      private GXWebComponent WebComp_Notificationscomponent ;
      private GXUserControl ucK2bhorizontalmenu ;
      private GXUserControl ucK2baccordionmenu ;
      private IGxDataStore dsDefault ;
      private GXDataAreaControl Contholder1 ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxSimpleCollection<String> AV24GXV1 ;
      private GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> AV9MenuItems ;
      private GXBaseCollection<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> GXt_objcol_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem1 ;
      private GXBaseCollection<SdtSearchableTransactions_SearchableTransactionsItem> AV12SearchableTransactions ;
      private GXBaseCollection<SdtSearchableTransactions_SearchableTransactionsItem> GXt_objcol_SdtSearchableTransactions_SearchableTransactionsItem2 ;
      private GXWebForm Form ;
   }

}
