using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace DisasmUiTest {
    /// <summary>
    /// Classes and data generation for SelectionTest.
    /// 
    /// Based on https://stackoverflow.com/q/21940875/294248
    /// </summary>
    public partial class SelectionTestWindow : Window, INotifyPropertyChanged {
        /// <summary>
        /// Number of items to show.  Raise this to 100,000+ to evaluate performance rather
        /// than correctness.
        /// </summary>
        private const int TEST_ITEM_COUNT = 1000;

        public class DataItem : INotifyPropertyChanged {
            public string ColZero { get; private set; }
            public string ColOne { get; private set; }
            public string ColTwo { get; private set; }

            // The item's IsSelected property is bound to this, giving us an easy way to
            // access the value.
            private bool mIsSelected;
            public bool IsSelected {
                get { return mIsSelected; }
                set {
                    mIsSelected = value;
                    OnPropertyChanged();
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "") {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

            public DataItem(string zero, string one, string two) {
                ColZero = zero;
                ColOne = one;
                ColTwo = two;
            }
        }

        public ObservableCollection<DataItem> DataSource { get; private set; }


        public SelectionTestWindow() {
            InitializeComponent();

            DataContext = this;
            DataSource = new ObservableCollection<DataItem>();

            // put a bunch of stuff into the list
            for (int i = 0; i < TEST_ITEM_COUNT; i++) {
                DataItem newItem = new DataItem("z" + i, "o" + i, "t" + i);
                DataSource.Add(newItem);
            }
        }

        /// <summary>
        /// Demonstrates programmatic item selection.
        /// </summary>
        /// <remarks>
        /// A "select all" feature implemented this way is an order of magnitude faster than
        /// calling testListView.SelectAll().  However, you only get SelectionChanged events
        /// for what's on-screen, and as you scroll around the events start trickling in for
        /// items when they become visible.  This makes selection management a bit tricky, but
        /// it seems to be the only way to get decent performance for a list with 100K+ elements.
        /// </remarks>
        private void SelectEvenRows_Click(object sender, RoutedEventArgs e) {
            for (int i = 0; i < DataSource.Count; i++) {
                DataSource[i].IsSelected = (i & 1) == 0;
            }
        }


        #region Selection tracking

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int mSelectionCount;
        public int SelectionCount {
            get { return mSelectionCount; }
            private set {
                mSelectionCount = value;
                OnPropertyChanged();
            }
        }

        private void TestListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            int delta = e.AddedItems.Count - e.RemovedItems.Count;
            SelectionCount += delta;

            if (fixIt.IsChecked == true) {
                int fixedAdd = 0;
                foreach (DataItem item in e.AddedItems) {
                    if (!item.IsSelected) {
                        item.IsSelected = true;
                        fixedAdd++;
                    }
                }
                int fixedRem = 0;
                foreach (DataItem item in e.RemovedItems) {
                    if (item.IsSelected) {
                        item.IsSelected = false;
                        fixedRem++;
                    }
                }

                Debug.WriteLine("Fix add=" + fixedAdd + " (of " + e.AddedItems.Count +
                    "), fix rem=" + fixedRem + " (of " + e.RemovedItems.Count + ")");
            }
        }

        #endregion Selection tracking
    }
}
