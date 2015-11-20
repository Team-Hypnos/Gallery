'use strict';

galleryApp.controller('AddPostController', function AddPostController($scope, $location, createPost) {
    var isLogged = localStorage.getItem('isLoggedIn');

    // Redirect the user if it is not logged
    if (!isLogged) {
        $location.path('/signin');
    }

    // Provides a collection of all cities
    $scope.townsCollection = [
        {
            value: 1,
            label: 'Aitos'
        },
        {
            value: 2,
            label: 'Asenovgrad'
        },
        {
            value: 3,
            label: 'Blagoevgrad'
        },
        {
            value: 4,
            label: 'Botevgrad'
        },
        {
            value: 5,
            label: 'Burgas'
        },
        {
            value: 6,
            label: 'Chirpan'
        },
        {
            value: 7,
            label: 'Dobrich'
        },
        {
            value: 8,
            label: 'Dupnica'
        },
        {
            value: 9,
            label: 'Gabrovo'
        },
        {
            value: 10,
            label: 'Gotse Delchev'
        },
        {
            value: 11,
            label: 'Haskovo'
        },
        {
            value: 12,
            label: 'Kardzhali'
        },
        {
            value: 13,
            label: 'Karlovo'
        },
        {
            value: 14,
            label: 'Karnobat'
        },
        {
            value: 15,
            label: 'Kazanlak'
        },
        {
            value: 16,
            label: 'Kyustendil'
        },
        {
            value: 17,
            label: 'Lom'
        },
        {
            value: 18,
            label: 'Lovech'
        },
        {
            value: 19,
            label: 'Montana'
        },
        {
            value: 20,
            label: 'Nova Zagora'
        },
        {
            value: 21,
            label: 'Panagurishte'
        },
        {
            value: 22,
            label: 'Pazardzhik'
        },
        {
            value: 23,
            label: 'Pernik'
        },
        {
            value: 24,
            label: 'Petrich'
        },
        {
            value: 25,
            label: 'Pleven'
        },
        {
            value: 26,
            label: 'Plovdiv'
        },
        {
            value: 27,
            label: 'Razgrad'
        },
        {
            value: 28,
            label: 'Ruse'
        },
        {
            value: 29,
            label: 'Samokov'
        },
        {
            value: 30,
            label: 'Sandanski'
        },
        {
            value: 31,
            label: 'Sevlievo'
        },
        {
            value: 32,
            label: 'Shumen'
        },
        {
            value: 33,
            label: 'Silistra'
        },
        {
            value: 34,
            label: 'Sliven'
        },
        {
            value: 35,
            label: 'Smolian'
        },
        {
            value: 36,
            label: 'Sofia'
        },
        {
            value: 37,
            label: 'Stara Zagora'
        },
        {
            value: 38,
            label: 'Svilengrad'
        },
        {
            value: 39,
            label: 'Troyan'
        },
        {
            value: 40,
            label: 'Varna'
        },
        {
            value: 41,
            label: 'Veliko Tarnovo'
        },
        {
            value: 42,
            label: 'Velingrad'
        },
        {
            value: 43,
            label: 'Vidin'
        },
        {
            value: 44,
            label: 'Vratsa'
        },
        {
            value: 45,
            label: 'Yambol'
        }
    ];

    // Provides a collection of all categories
    $scope.categoriesCollection = [
        {
            value: 1,
            label: 'Nature'
        },
        {
            value: 2,
            label: 'Historical monuments'
        },
        {
            value: 3,
            label: 'City life'
        },
        {
            value: 4,
            label: 'City culture'
        },
        {
            value: 5,
            label: 'City festivals'
        }
    ];

    // Creates new post
    // Sends: title, description, the name of the city, category, picture
    $scope.addNewPost = function () {
        var fileData = new FormData();
        var files = $('#image-input').get(0).files;

        if (files.length > 0) {
            fileData.append('UploadedImage', files[0]);
        }

        var post = {
            title: $scope.postTitle,
            description: $scope.postDescription,
            townId: $scope.townsList.value,
            userId: localStorage.getItem('username'),
            isDeleted: false,
            pictureData: fileData
        };

        console.log(post);

        createPost.createNewPost(post)
            .then(function () {
                $location.path('/home');
            })
    };

});