'use strict';

galleryApp.factory('createPost', function ($resource, $q, $http) {
    var remoteUrl = 'http://localhost:6299/';

    return {
        createNewPost: function (postObj) {
            var deferred = $q.defer();

            $http.post(remoteUrl + 'api/posts', {
                    title: postObj.title,
                    description: postObj.description,
                    userId: postObj.userId,
                    townId: postObj.townId,
                    isDeleted: postObj.isDeleted,
                    pictureData: postObj.pictureData
                },
                {
                    headers: {
                        'Authorization': 'Bearer ' + localStorage.getItem('access_token'),
                        'Access-Control-Allow-Origin': '*'
                    }
                }
            )
                .success(function (data) {
                    toastr.success('A new post has been successfully added :)', '', {"positionClass": "toast-bottom-right"});
                    deferred.resolve(data);
                })
                .error(function (error) {
                    toastr.error('Something went wrong. Please try again.', '', {"positionClass": "toast-bottom-right"});
                    deferred.reject(error);
                });

            return deferred.promise;
        }
    };
});