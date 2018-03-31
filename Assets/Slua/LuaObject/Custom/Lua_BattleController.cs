using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_BattleController : LuaObject {
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"BattleController");
		createTypeMetatable(l,null, typeof(BattleController),typeof(UnityEngine.MonoBehaviour));
	}
}
