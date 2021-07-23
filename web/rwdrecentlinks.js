gx.evt.autoSkip = false;
gx.define('rwdrecentlinks', true, function (CmpContext) {
   this.ServerClass =  "rwdrecentlinks" ;
   this.PackageName =  "GeneXus.Programs" ;
   this.ServerFullClass =  "rwdrecentlinks.aspx" ;
   this.setObjectType("web");
   this.setCmpContext(CmpContext);
   this.ReadonlyForm = true;
   this.hasEnterEvent = false;
   this.skipOnEnter = false;
   this.autoRefresh = true;
   this.fullAjax = true;
   this.supportAjaxEvents =  true ;
   this.ajaxSecurityToken =  true ;
   this.SetStandaloneVars=function()
   {
      this.AV6FormCaption=gx.fn.getControlValue("vFORMCAPTION") ;
      this.AV7FormPgmName=gx.fn.getControlValue("vFORMPGMNAME") ;
      this.AV6FormCaption=gx.fn.getControlValue("vFORMCAPTION") ;
   };
   this.e11051_client=function()
   {
      this.clearMessages();
      if ( gx.text.compare( gx.fn.getCtrlProperty("MAINTABLE","Class") , "RecentLinksMainTable" ) == 0 )
      {
         gx.fn.setCtrlProperty("MAINTABLE","Class", "RecentLinksMainTable RecentLinksMainTableExpanded" );
      }
      else
      {
         gx.fn.setCtrlProperty("MAINTABLE","Class", "RecentLinksMainTable" );
      }
      this.refreshOutputs([{av:'gx.fn.getCtrlProperty("MAINTABLE","Class")',ctrl:'MAINTABLE',prop:'Class'}]);
      this.OnClientEventEnd();
      return gx.$.Deferred().resolve();
   };
   this.e13052_client=function()
   {
      return this.executeServerEvent("ENTER", true, arguments[0], false, false);
   };
   this.e14052_client=function()
   {
      return this.executeServerEvent("CANCEL", true, arguments[0], false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,9,10,11,12];
   this.GXLastCtrlId =12;
   this.LinksContainer = new gx.grid.grid(this, 2,"WbpLvl2",8,"Links","Links","LinksContainer",this.CmpContext,this.IsMasterPage,"rwdrecentlinks",[],true,9999,false,true,0,false,false,false,"",0,"px",0,"px","Novo registro",false,false,false,null,null,false,"",true,[1,0,0,0],false,0,false,false);
   var LinksContainer = this.LinksContainer;
   LinksContainer.startDiv(9,"Linkstable","0px","0px");
   LinksContainer.startDiv(10,"","0px","0px");
   LinksContainer.startDiv(11,"","0px","0px");
   LinksContainer.addTextBlock('PLACE',null,12);
   LinksContainer.endDiv();
   LinksContainer.endDiv();
   LinksContainer.endDiv();
   this.LinksContainer.emptyText = "";
   this.setGrid(LinksContainer);
   GXValidFnc[2]={ id: 2, fld:"",grid:0};
   GXValidFnc[3]={ id: 3, fld:"MAINTABLE",grid:0};
   GXValidFnc[4]={ id: 4, fld:"",grid:0};
   GXValidFnc[5]={ id: 5, fld:"",grid:0};
   GXValidFnc[6]={ id: 6, fld:"RECENTTEXT", format:0,grid:0,evt:"e11051_client", ctrltype: "textblock"};
   GXValidFnc[7]={ id: 7, fld:"",grid:0};
   GXValidFnc[9]={ id: 9, fld:"LINKSTABLE",grid:8};
   GXValidFnc[10]={ id: 10, fld:"",grid:8};
   GXValidFnc[11]={ id: 11, fld:"",grid:8};
   GXValidFnc[12]={ id: 12, fld:"PLACE", format:0,grid:8, ctrltype: "textblock"};
   this.AV6FormCaption = "" ;
   this.AV7FormPgmName = "" ;
   this.Events = {"e13052_client": ["ENTER", true] ,"e14052_client": ["CANCEL", true] ,"e11051_client": ["RECENTTEXT.CLICK", false]};
   this.EvtParms["REFRESH"] = [[{av:'LINKS_nFirstRecordOnPage'},{av:'LINKS_nEOF'},{av:'AV6FormCaption',fld:'vFORMCAPTION',pic:''},{av:'sPrefix'}],[]];
   this.EvtParms["RECENTTEXT.CLICK"] = [[{av:'gx.fn.getCtrlProperty("MAINTABLE","Class")',ctrl:'MAINTABLE',prop:'Class'}],[{av:'gx.fn.getCtrlProperty("MAINTABLE","Class")',ctrl:'MAINTABLE',prop:'Class'}]];
   this.EvtParms["LINKS.LOAD"] = [[{av:'AV6FormCaption',fld:'vFORMCAPTION',pic:''}],[{av:'gx.fn.getCtrlProperty("PLACE","Caption")',ctrl:'PLACE',prop:'Caption'},{av:'gx.fn.getCtrlProperty("PLACE","Link")',ctrl:'PLACE',prop:'Link'}]];
   this.setVCMap("AV6FormCaption", "vFORMCAPTION", 0, "char", 100, 0);
   this.setVCMap("AV7FormPgmName", "vFORMPGMNAME", 0, "svchar", 256, 0);
   this.setVCMap("AV6FormCaption", "vFORMCAPTION", 0, "char", 100, 0);
   this.setVCMap("AV6FormCaption", "vFORMCAPTION", 0, "char", 100, 0);
   LinksContainer.addRefreshingVar({rfrVar:"AV6FormCaption"});
   LinksContainer.addRefreshingParm({rfrVar:"AV6FormCaption"});
   this.Initialize( );
});
