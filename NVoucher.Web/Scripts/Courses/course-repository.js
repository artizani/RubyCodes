registrationModule.factory('resultRepository', function($resource) {
    return {
        get: function() {
            return $resource('api/ProductResult/Codes').query();
        }
    }
});