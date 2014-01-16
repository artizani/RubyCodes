'use strict';

// the storeController contains two objects:
// - store: contains the product list
// - cart: the shopping cart object
registrationModule.controller("StoreController", ['$scope', '$routeParams', 'storeRepository', function ($scope, $routeParams, storeRepository) {

    // get store and cart from service
    $scope.store = storeRepository.store;
    $scope.cart = storeRepository.cart;
    $scope.cartItems = storeRepository.cart.items;

    $scope.postcart = function () {

        console.log($scope.cartItems);
        $scope.error = false;
        //  orderRepository.get(cartItems);
        return storeRepository.save($scope.cartItems, function (data) {
            console.log(data);
        });

    };
    
    
    
  
    // use routing to pick the selected product
    if ($routeParams.productSku != null) {
        $scope.product = $scope.store.getProduct($routeParams.productSku);
      
    }
}]);


