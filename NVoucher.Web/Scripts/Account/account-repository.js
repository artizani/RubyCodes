'use strict';

registrationModule.factory('accountRepository', function($resource) {
    return {
        save: function (profile) {
            return $resource('/api/Account/Register').save(profile);
        }
    };
});