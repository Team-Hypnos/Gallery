'use strict';

galleryApp.factory('userAuthentication', function ($resource, $q, $http) {
    var remoteUrl = '';

    return {
        register: function (firstName, lastName, username, password) {
            var deferred = $q.defer();

            $http.post(remoteUrl + 'api/register', {
                    FirstName: firstName,
                    LastName: lastName,
                    Username: username,
                    Password: password
                },
                {
                    transformRequest: function (queryPair) {
                        var queryElements = [];
                        for (var key in queryPair) {
                            var encodedKey = encodeURIComponent(key);
                            var encodedValue = encodeURIComponent(queryPair[key]);

                            queryElements.push(encodedKey + "=" + encodedValue);
                        }

                        return queryElements.join("&");
                    },
                    headers: {
                        'Content-Type': 'application/x-www-form-urlencoded'
                    }
                })
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (error) {
                    deferred.reject(error);
                });

            return deferred.promise;
        },
        login: function (username, password) {
            var deferred = $q.defer();

            $http.post(remoteUrl + 'Token', {
                    username: username,
                    password: password
                },
                {
                    transformRequest: function (queryPair) {
                        var queryElements = [];
                        for (var key in queryPair) {
                            var encodedKey = encodeURIComponent(key);
                            var encodedValue = encodeURIComponent(queryPair[key]);

                            queryElements.push(encodedKey + "=" + encodedValue);
                        }

                        return queryElements.join("&");
                    },
                    headers: {
                        'Content-Type': 'application/x-www-form-urlencoded'
                    }
                })
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (error) {
                    deferred.reject(error);
                });

            return deferred.promise;
        }
    };
});