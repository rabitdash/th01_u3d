using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_CardManager : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get__instance(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,CardManager._instance);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set__instance(IntPtr l) {
		try {
			CardManager v;
			checkType(l,2,out v);
			CardManager._instance=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_cardPrefab(IntPtr l) {
		try {
			CardManager self=(CardManager)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.cardPrefab);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_cardPrefab(IntPtr l) {
		try {
			CardManager self=(CardManager)checkSelf(l);
			UnityEngine.GameObject v;
			checkType(l,2,out v);
			self.cardPrefab=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_publicCardHeap(IntPtr l) {
		try {
			CardManager self=(CardManager)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.publicCardHeap);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_publicCardHeap(IntPtr l) {
		try {
			CardManager self=(CardManager)checkSelf(l);
			UnityEngine.GameObject v;
			checkType(l,2,out v);
			self.publicCardHeap=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_publicDropHeap(IntPtr l) {
		try {
			CardManager self=(CardManager)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.publicDropHeap);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_publicDropHeap(IntPtr l) {
		try {
			CardManager self=(CardManager)checkSelf(l);
			UnityEngine.GameObject v;
			checkType(l,2,out v);
			self.publicDropHeap=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_nplayer(IntPtr l) {
		try {
			CardManager self=(CardManager)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.nplayer);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_nplayer(IntPtr l) {
		try {
			CardManager self=(CardManager)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.nplayer=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"CardManager");
		addMember(l,"_instance",get__instance,set__instance,false);
		addMember(l,"cardPrefab",get_cardPrefab,set_cardPrefab,true);
		addMember(l,"publicCardHeap",get_publicCardHeap,set_publicCardHeap,true);
		addMember(l,"publicDropHeap",get_publicDropHeap,set_publicDropHeap,true);
		addMember(l,"nplayer",get_nplayer,set_nplayer,true);
		createTypeMetatable(l,null, typeof(CardManager),typeof(UnityEngine.MonoBehaviour));
	}
}
