function changeMessage(messageId, messageText) {
    const sendBtn = document.getElementById("sendMessageId");

    if (sendBtn.value === "Send") {
        sendBtn.value = "Edit";
        document.getElementById("messageInputId").value = messageText;
        document.getElementById("editMessageId").value = messageId;
    } else {
        sendBtn.value = "Send";
        document.getElementById("editMessageId").value = "";
    }
}

$(function () {
    $("form[name='messageSendForm']").validate({
        rules: {
            messageInput: {
                required: true
            }
        },

        messages: {
            required: "You can't send empty messages"
        },
    });
});