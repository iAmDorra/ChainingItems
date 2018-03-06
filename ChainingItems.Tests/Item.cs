namespace ChainingItems.Tests
{
    internal class Item
    {
        private int identifier;
        private int? previousItemIdentifier;
        private int? followingItemIdentifier;

        public Item(int identifier, int? previousItemIdentifier, int? followingItemIdentifier)
        {
            this.identifier = identifier;
            this.previousItemIdentifier = previousItemIdentifier;
            this.followingItemIdentifier = followingItemIdentifier;
        }

        public int Identifier { get => identifier; }
        public int? PreviousItemId { get => previousItemIdentifier; }
        public int? FollowingITemId { get => followingItemIdentifier; }
    }
}