using System;
using System.Collections.Generic;

namespace NetStudy.Algorithms.Btree
{
    public class BTreeNode
    {
        public int[] _keys; // An array of keys
        public int t;   // Minimum degree (defines the range for number of keys)
        public int _key;   // Current number of keys
        public bool _leaf; // Is true when node is leaf. Otherwise false
        public IList<BTreeNode> _children; // An array of child pointers
        public BTreeNode(int _t, bool _leaf)
        {
            // Copy the given minimum degree and leaf property
            t = _t;
            this._leaf = _leaf;

            // Allocate memory for maximum number of possible keys
            // and child pointers
            _keys = new int[2 * t - 1];
            _children = new BTreeNode[2 * t];

            // Initialize the number of keys as 0
            _key = 0;
        }
        public void Traverse()
        {
            // There are n keys and n+1 children, travers through n keys
            // and first n children
            int i;
            for (i = 0; i < _key; i++)
            {
                // If this is not leaf, then before printing key[i],
                // traverse the subtree rooted with child C[i].
                if (_leaf == false)
                    _children[i].Traverse();
                Console.WriteLine(" " + _keys[i]);
            }

            // Print the subtree rooted with last child
            if (_leaf == false)
                _children[i].Traverse();
        }
        public BTreeNode Search(int k)
        {
            // Find the first key greater than or equal to k
            int i = 0;
            while (i < _key && k > _keys[i])
                i++;

            // If the found key is equal to k, return this node
            if (_keys[i] == k)
                return this;

            // If the key is not found here and this is a leaf node
            if (_leaf == true)
                return null;

            // Go to the appropriate child
            return _children[i].Search(k);
        }
        public void InsertNonFull(int k)
        {
            // Initialize index as index of rightmost element
            int i = _key - 1;

            // If this is a leaf node
            if (_leaf == true)
            {
                // The following loop does two things
                // a) Finds the location of new key to be inserted
                // b) Moves all greater keys to one place ahead
                while (i >= 0 && _keys[i] > k)
                {
                    _keys[i + 1] = _keys[i];
                    i--;
                }

                // Insert the new key at found location
                _keys[i + 1] = k;
                _key = _key + 1;
            }
            else // If this node is not leaf
            {
                // Find the child which is going to have the new key
                while (i >= 0 && _keys[i] > k)
                    i--;

                // See if the found child is full
                if (_children[i + 1]._key == 2 * t - 1)
                {
                    // If the child is full, then split it
                    SplitChild(i + 1, _children[i + 1]);

                    // After split, the middle key of C[i] goes up and
                    // C[i] is splitted into two.  See which of the two
                    // is going to have the new key
                    if (_keys[i + 1] < k)
                        i++;
                }
                _children[i + 1].InsertNonFull(k);
            }
        }

        public void SplitChild(int i, BTreeNode y)
        {
            // Create a new node which is going to store (t-1) keys
            // of y
            BTreeNode z = new BTreeNode(y.t, y._leaf);
            z._key = t - 1;

            // Copy the last (t-1) keys of y to z
            for (int j = 0; j < t - 1; j++)
                z._keys[j] = y._keys[j + t];

            // Copy the last t children of y to z
            if (y._leaf == false)
            {
                for (int j = 0; j < t; j++)
                    z._children[j] = y._children[j + t];
            }

            // Reduce the number of keys in y
            y._key = t - 1;

            // Since this node is going to have a new child,
            // create space of new child
            for (int j = _key; j >= i + 1; j--)
                _children[j + 1] = _children[j];

            // Link the new child to this node
            _children[i + 1] = z;

            // A key of y will move to this node. Find location of
            // new key and move all greater keys one space ahead
            for (int j = _key - 1; j >= i; j--)
                _keys[j + 1] = _keys[j];

            // Copy the middle key of y to this node
            _keys[i] = y._keys[t - 1];

            // Increment count of keys in this node
            _key = _key + 1;
        }
    };
}