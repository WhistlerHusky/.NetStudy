namespace NetStudy.Algorithms.Btree
{
    public class BTree
    {
        BTreeNode _root; // Pointer to root node
        int _t; // Minimum degree
        public BTree(int _t)
        {
            _root = null;
            this._t = _t;
        }

        // function to traverse the tree
        public void traverse()
        {
            _root?.Traverse();
        }

        // function to search a key in this tree
        public BTreeNode search(int k)
        {
            return _root?.Search(k);
        }

        public void Insert(int k)
        {
            // If tree is empty
            if (_root == null)
            {
                // Allocate memory for root
                _root = new BTreeNode(_t, true);
                _root._keys[0] = k;  // Insert key
                _root._key = 1;  // Update number of keys in root
            }
            else // If tree is not empty
            {
                // If root is full, then tree grows in height
                if (_root._key == 2 * _t - 1)
                {
                    // Allocate memory for new root
                    BTreeNode s = new BTreeNode(_t, false);

                    // Make old root as child of new root
                    s._children[0] = _root;

                    // Split the old root and move 1 key to the new root
                    s.SplitChild(0, _root);

                    // New root has two children now.  Decide which of the
                    // two children is going to have new key
                    int i = 0;
                    if (s._keys[0] < k)
                        i++;
                    s._children[i].InsertNonFull(k);

                    // Change root
                    _root = s;
                }
                else  // If root is not full, call insertNonFull for root
                    _root.InsertNonFull(k);
            }
        }

    };
}