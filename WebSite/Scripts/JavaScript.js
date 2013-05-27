
function scanparms(fn)
{
   var FN_ARGS = /^function\s*[^\(]*\(\s*([^\)]*)\)/m;
   var FN_ARG_SPLIT = /,/;
   var FN_ARG = /^\s*(_?)(\S+?)\1\s*$/;
   var STRIP_COMMENTS = /((\/\/.*$)|(\/\*[\s\S]*?\*\/))/mg;
   return annotate(fn);
   function annotate(fn) 
   {
     var $inject,
         fnText,
         argDecl,
         last;

     if (typeof fn == 'function') {
       if (!($inject = fn.$inject)) {
         $inject = [];
         fnText = fn.toString().replace(STRIP_COMMENTS, '');
         argDecl = fnText.match(FN_ARGS);
         var aaaa = argDecl[1].split(FN_ARG_SPLIT);
         aaaa.forEach(
         function(arg){
           arg.replace(FN_ARG, function(all, underscore, name){
             $inject.push(name);
           });
         });
         fn.$inject = $inject;
       }
     }
     return $inject;
   }
}

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
};






