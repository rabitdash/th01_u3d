using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_Player : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			Player o;
			System.Int32 a1;
			checkType(l,2,out a1);
			System.Collections.Generic.List<System.String> a2;
			checkType(l,3,out a2);
			o=new Player(a1,a2);
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Start(IntPtr l) {
		try {
			Player self=(Player)checkSelf(l);
			self.Start();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int AddCards(IntPtr l) {
		try {
			Player self=(Player)checkSelf(l);
			System.Collections.Generic.List<System.String> a1;
			checkType(l,2,out a1);
			self.AddCards(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int DropCards(IntPtr l) {
		try {
			Player self=(Player)checkSelf(l);
			System.Collections.Generic.List<System.String> a1;
			checkType(l,2,out a1);
			self.DropCards(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_heldCards(IntPtr l) {
		try {
			Player self=(Player)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.heldCards);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_heldCards(IntPtr l) {
		try {
			Player self=(Player)checkSelf(l);
			System.Collections.Generic.List<System.String> v;
			checkType(l,2,out v);
			self.heldCards=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_isMyTurn(IntPtr l) {
		try {
			Player self=(Player)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.isMyTurn);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_isMyTurn(IntPtr l) {
		try {
			Player self=(Player)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.isMyTurn=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_isTimeUp(IntPtr l) {
		try {
			Player self=(Player)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.isTimeUp);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_isTimeUp(IntPtr l) {
		try {
			Player self=(Player)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.isTimeUp=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_myNum(IntPtr l) {
		try {
			Player self=(Player)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.myNum);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_myNum(IntPtr l) {
		try {
			Player self=(Player)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.myNum=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"Player");
		addMember(l,Start);
		addMember(l,AddCards);
		addMember(l,DropCards);
		addMember(l,"heldCards",get_heldCards,set_heldCards,true);
		addMember(l,"isMyTurn",get_isMyTurn,set_isMyTurn,true);
		addMember(l,"isTimeUp",get_isTimeUp,set_isTimeUp,true);
		addMember(l,"myNum",get_myNum,set_myNum,true);
		createTypeMetatable(l,constructor, typeof(Player));
	}
}
