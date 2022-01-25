export class StringUtils {
    public static replaceAll(text: string, oldValue: string, newValue: string): string {
        return text.split(oldValue).join(newValue);
    }

    public static hashCode(text: string): number {
        let hash: number = 0;
        let chr: number;
        for (let i = 0; i < text.length; i++) {
            chr = text.charCodeAt(i);
            hash = ((hash << 5) - hash) + chr;
            hash |= 0;
        }
        return hash;
    }

    public static isEmptyOrWhiteSpace(value: string | undefined): boolean {
        return !value || value.trim().length === 0;
    }

    public static compare (a: string, b: string): number {
        if (a > b) {
            return 1;
        } else if (a < b) {
            return -1;
        } else {
            return 0;
        }
    }
}