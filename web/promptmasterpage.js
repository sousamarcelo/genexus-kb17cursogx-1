gx.evt.autoSkip = false;
gx.define('promptmasterpage', false, function () {
   this.ServerClass =  "promptmasterpage" ;
   this.PackageName =  "GeneXus.Programs" ;
   this.ServerFullClass =  "promptmasterpage.aspx" ;
   this.setObjectType("web");
   this.IsMasterPage=true;
   this.hasEnterEvent = false;
   this.skipOnEnter = false;
   this.autoRefresh = true;
   this.fullAjax = true;
   this.supportAjaxEvents =  true ;
   this.ajaxSecurityToken =  true ;
   this.SetStandaloneVars=function()
   {
   };
   this.e14032_client=function()
   {
      return this.executeServerEvent("ENTER_MPAGE", true, null, false, false);
   };
   this.e15032_client=function()
   {
      return this.executeServerEvent("CANCEL_MPAGE", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,8,15,18,21,24,27,28,31];
   this.GXLastCtrlId =31;
   GXValidFnc[2]={ id: 2, fld:"TABLE2",grid:0};
   GXValidFnc[8]={ id: 8, fld:"TABLE3",grid:0};
   GXValidFnc[15]={ id: 15, fld:"TABLE4",grid:0};
   GXValidFnc[18]={ id: 18, fld:"TABLE5",grid:0};
   GXValidFnc[21]={ id: 21, fld:"TABLE6",grid:0};
   GXValidFnc[24]={ id: 24, fld:"TABLE1",grid:0};
   GXValidFnc[27]={ id: 27, fld:"TEXTBLOCK1", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[28]={ id: 28, fld:"TABLE7",grid:0};
   GXValidFnc[31]={ id: 31, fld:"TABLE8",grid:0};
   this.Events = {"e14032_client": ["ENTER_MPAGE", true] ,"e15032_client": ["CANCEL_MPAGE", true]};
   this.EvtParms["REFRESH_MPAGE"] = [[],[]];
   this.EvtParms["START_MPAGE"] = [[],[]];
   this.Initialize( );
});
gx.wi( function() { gx.createMasterPage(promptmasterpage);});
