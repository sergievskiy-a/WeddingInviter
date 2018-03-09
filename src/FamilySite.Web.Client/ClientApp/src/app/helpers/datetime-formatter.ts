export class DateTimeFormatter {
    public static format(dateTime: string) {
        const date = new Date(dateTime);

        const result =
        (date.getFullYear() + '-' + ((date.getMonth() + 1))
        + '-' + date.getDate() + ' ' + date.getHours() + ':' + date.getMinutes());

        return result;
    }
}
