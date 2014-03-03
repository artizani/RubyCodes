registrationModule.factory('instructorRepository', function ($resource) {
    return {
        get: function() {
            return $resource('api/Fund/Summary/').query();
        }
    };
});