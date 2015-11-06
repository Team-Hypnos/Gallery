'use strict';

galleryApp.controller('SignInController', function SignInController($scope, $resource, userAuthentication, $location) {
    $scope.signIn = function () {
        userAuthentication.login($scope.username, $scope.password)
            .then(function (data) {
                $location.path('/home');
                localStorage.setItem('isLoggedIn', true);
                localStorage.setItem('access_token', data.acces_token);
                localStorage.setItem('username', data.username);
            });
    };
});
