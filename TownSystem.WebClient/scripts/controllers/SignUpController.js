'use strict';

galleryApp.controller('SignUpController', function SignUpController($scope, $resource, userAuthentication, $location) {
    $scope.signUp = function () {
        userAuthentication.register($scope.firstname, $scope.lastname, $scope.username, $scope.password)
            .then(function () {
                $location.path('/signin');
            });
    };
});