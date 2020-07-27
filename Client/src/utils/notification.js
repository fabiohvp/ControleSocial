class UserNotification {
  constructor(title, body, data, dir = "ltr") {
    this.title = title;
    this.settings = {
      body,
      dir,
      data
    };
  }
  emit() {
    this.notificationEmit = new Notification(this.title, this.settings);
  }
  close() {
    this.notificationEmit.close();
  }
  onClick(callbackFunction) {
    this.notificationEmit.addEventListener("click", e => {
      callbackFunction(e);
    });
  }
}

async function notify(title, body, data) {
  if (Notification === undefined) {
    console.log("Este navegador não suporta notificações");
    return;
  }

  let permission = Notification.permission;

  if (permission !== "granted") {
    permission = await Notification.requestPermission();
  }

  if (permission) {
    emit(title, body, data);
  }
}

function emit(title, body, data) {
  const notification = new UserNotification(title, body, data);

  notification.emit();

  if (data) {
    notification.onClick(e => window.open(e.target.data));
  }
}

export default notify;
