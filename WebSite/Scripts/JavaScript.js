
ss.isSubclassOf = function(target, type) {
	if (target.__class) {
		var baseType = target.__baseType;
		while (baseType) {
			if (type == baseType) {
				return true;
			}
			baseType = baseType.__baseType;
		}
	}
	return false;
}



