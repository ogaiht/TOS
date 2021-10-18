import { Predicate } from '../common.types';

export class CollectionHelper {
    public static where<TKey, TValue>(collection: Map<TKey, TValue>, where: Predicate<[TKey, TValue]>): [TKey, TValue][] {
        const selectedEntries: [TKey, TValue][] = [];
        for(const entry of collection.entries()) {
            if (where(entry)) {
                selectedEntries.push(entry);
            }
        }
        return selectedEntries;
    }

    public static remove<TKey, TValue>(collection: Map<TKey, TValue>, where: Predicate<[TKey, TValue]>): number {
        const items:[TKey, TValue][] = CollectionHelper.where(collection, (entry: [TKey, TValue]) => where(entry));
        let removedItemsCount = 0;
        for (const entry of items) {
            if (collection.delete(entry[0])) {
                removedItemsCount++;
            }
        }
        return removedItemsCount;
    }
}