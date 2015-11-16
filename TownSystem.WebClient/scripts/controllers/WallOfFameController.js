'use strict';

galleryApp.controller("WallOfFameController", function WallOfFameController($scope, PubNub){
    var currentUser = localStorage.getItem('username');
    var currentChannel = 'Bulgaria best town - wall of fame';

    var $input = $('#chat-input');
    var $output = $('#chat-output');

    //PubNub.init({
    //    publish_key: 'pub-c-b333b488-6cc7-46ea-adc3-6c45b197c30b',
    //    subscribe_key: 'sub-c-ba358d14-8be7-11e5-8b47-02ee2ddab7fe',
    //    uuid: currentUser
    //});

    // Publish message
    //$scope.publish = function() {
    //    PubNub.ngPublish({
    //        channel: currentChannel,
    //        message: $scope.newMessage
    //    });
    //};

    var pubnub = PUBNUB.init({
        publish_key: 'pub-c-b333b488-6cc7-46ea-adc3-6c45b197c30b',
        subscribe_key: 'sub-c-ba358d14-8be7-11e5-8b47-02ee2ddab7fe'
    });

    $('#chat').submit(function() {

        pubnub.publish({
            channel: currentChannel,
            message: {
                text: $input.val(),
                username: currentUser
            }
        });

        $input.val('');

        return false;

    });

    pubnub.subscribe({
        channel: currentChannel,
        message: function(data) {

            var $line = $('<li class="list-group-item"><strong>' + data.username + ':</strong> </span>');
            var $message = $('<span class="text" />').text(data.text).html();

            if(data.username == currentUser) {
                $line.addClass('me');
            }

            $line.append($message);
            $output.append($line);

            $output.scrollTop($output[0].scrollHeight);

        }
    });

    // Listen for messages
    //PubNub.ngSubscribe({
    //    channel: currentChannel,
    //    callback: function() { console.log(arguments); }
    //});
});