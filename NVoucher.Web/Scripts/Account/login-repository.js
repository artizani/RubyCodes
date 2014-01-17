'use strict';

registrationModule.factory('loginRepository', function($resource,$http) {
    return $resource('/Token');


});
