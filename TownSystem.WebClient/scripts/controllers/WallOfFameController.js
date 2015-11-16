'use strict';

galleryApp.controller("WallOfFameController", function WallOfFameController($scope){
    $scope.best = [
        {
            cityName: 'Kystendil',
            likes: 35,
            picture: 'http://i2.offnews.bg/galleries/21441/20150224_2a38a4a9316c49e5a833517c45d31070_21445.jpg'
        },
        {
            cityName: 'Varna',
            likes: 29,
            picture: 'http://www.doubletreebyhiltonglobalmediacenter.com/assets/HHNR/images/galleries/topwintercities/europe/Varna_2.1.2012_HR.jpg'
        },
        {
            cityName: 'Plovdiv',
            likes: 27,
            picture: 'https://drscdn.500px.org/photo/25478259/m%3D2048/0c075d9aaa85d47bceeac03b82b83152'
        },
        {
            cityName: 'Sofia',
            likes: 23,
            picture: 'http://birdsphotographer.com/wp-content/uploads/2014/02/sofia-izgrev-sunrise-landscape-peizaj-wwwBirdsPhotographerCom__Nikolay-Staykov-8798.jpg'
        }
    ];

    var currentUser = localStorage.getItem('username');
    var currentChannel = 'Bulgaria best town - wall of fame';

    var input = $('#chat-input');
    var output = $('#chat-output');

    var pubnub = PUBNUB.init({
        publish_key: 'pub-c-b333b488-6cc7-46ea-adc3-6c45b197c30b',
        subscribe_key: 'sub-c-ba358d14-8be7-11e5-8b47-02ee2ddab7fe'
    });

    $('#chat').submit(function() {

        pubnub.publish({
            channel: currentChannel,
            message: {
                text: input.val(),
                username: currentUser
            }
        });

        input.val('');

        return false;
    });

    pubnub.subscribe({
        channel: currentChannel,
        message: function(data) {

            var $line = $('<li class="list-group-item"><strong>' + data.username + ':</strong> </span>');
            var $message = $('<span class="text" />').html(parseMessage(data.text));

            if(data.username === currentUser) {
                $line.addClass('my-self');
                $message.addClass('me-self-message')
            }

            $line.append($message);
            output.append($line);

            output.scrollTop(output[0].scrollHeight);
        }
    });

    function parseMessage(message){
        // Prevent hacking
        var message = message.replace('<script>', '');

        var parsedMessage = '',
            laughingEmoticon = '<img class="emoticon" src="./content/media/emoticons/laughing.png"/>',
            likeEmoticon = '<img class="emoticon" src="./content/media/emoticons/like.png"/>',
            sadEmoticon = '<img class="emoticon" src="./content/media/emoticons/sad.png"/>',
            smileEmoticon = '<img class="emoticon" src="./content/media/emoticons/smile.png"/>',
            winkEmoticon = '<img class="emoticon" src="./content/media/emoticons/wink.png"/>',
            awesomeEmoticon = '<img class="emoticon" src="./content/media/emoticons/awesome.png"/>',
            tongueEmoticon = '<img class="emoticon" src="./content/media/emoticons/tongue.png"/>';

        // Parser
        for (var i = 0; i < message.length; i++){
            if (message[i] === ':' && (message[i + 1] === 'D' || message[i + 1] === 'd')) {
                parsedMessage += laughingEmoticon;
                i += 1;
            } else if (message[i] === ':' && message[i + 1] === ')') {
                parsedMessage += smileEmoticon;
                i += 1;
            } else if (message[i] === ':' && message[i + 1] === '(') {
                parsedMessage += sadEmoticon;
                i += 1;
            } else if (message[i] === ';' && message[i + 1] === ')') {
                parsedMessage += winkEmoticon;
                i += 1;
            } else if (message[i] === '(' && (message[i + 1] === 'y' || message[i + 1] === 'Y') && message[i + 2] === ')') {
                parsedMessage += likeEmoticon;
                i += 2;
            }  else if (message[i] === ':' && message[i + 1] === '3'){
                parsedMessage += awesomeEmoticon;
                i += 1;
            } else if (message[i] === ':' && (message[i + 1] === 'P' || message[i + 1] === 'p')){
                parsedMessage += tongueEmoticon;
                i += 1;
            } else {
                parsedMessage += message[i];
            }
        }

        return parsedMessage;
    }
});