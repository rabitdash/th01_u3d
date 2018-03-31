using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_Card : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int InitCard(IntPtr l) {
		try {
			Card self=(Card)checkSelf(l);
			CardInfo a1;
			checkType(l,2,out a1);
			System.Int32 a2;
			checkType(l,3,out a2);
			self.InitCard(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int OnMouseEnter(IntPtr l) {
		try {
			Card self=(Card)checkSelf(l);
			self.OnMouseEnter();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int OnMouseExit(IntPtr l) {
		try {
			Card self=(Card)checkSelf(l);
			self.OnMouseExit();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int OnMouseDown(IntPtr l) {
		try {
			Card self=(Card)checkSelf(l);
			self.OnMouseDown();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_cardInfo(IntPtr l) {
		try {
			Card self=(Card)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.cardInfo);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_cardInfo(IntPtr l) {
		try {
			Card self=(Card)checkSelf(l);
			CardInfo v;
			checkType(l,2,out v);
			self.cardInfo=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"Card");
		addMember(l,InitCard);
		addMember(l,OnMouseEnter);
		addMember(l,OnMouseExit);
		addMember(l,OnMouseDown);
		addMember(l,"cardInfo",get_cardInfo,set_cardInfo,true);
		createTypeMetatable(l,null, typeof(Card),typeof(UnityEngine.MonoBehaviour));
	}
}
