"use strict";

registrationModule.factory('checkoutRepository', function ($resource) {
    return {
        get: function(data) {
            $resource('/api/Purchase', {}, { post: { method: 'GET', params: {}, isArray: true } }).save(data);
        }
    };
});