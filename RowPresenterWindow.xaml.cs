using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace DisasmUiTest {
    /// <summary>
    /// Code-behind for the GridViewRowPresenter approach.
    /// </summary>
    /// <remarks>
    /// Most of this is an experiment with tracking the column width manually in the code-behind,
    /// and pushing changes out through a notification-enabled property.  This wasn't a great
    /// plan, but I left the code in place for reference.
    /// </remarks>
    public partial class RowPresenterWindow : Window /*, INotifyPropertyChanged*/ {
#if false
        private int mWidth = 150;
        public int LongColZeroWidth {
            get { return mWidth; }
            set {
                mWidth = value;
                NotifyPropertyChanged();
            }
        }
#endif

        public RowPresenterWindow() {
            InitializeComponent();

#if false
            this.DataContext = this;

            // Receive an event whenever the column header's size changes.
            // (see http://geekswithblogs.net/lbugnion/archive/2008/05/06/wpf-listviewgridview-minimum-and-maximum-width-for-a-column.aspx )
            codeListView.AddHandler(Thumb.DragDeltaEvent,
                new DragDeltaEventHandler(Thumb_DragDelta), true);

            // TODO: this doesn't work -- auto-sizing must be happening later -- need to catch
            //       an event that happens late
            ComputeColZeroWidth();

            // TODO: sum up the widths of the last 4 columns and use it to set the width of
            //       column 1, so that the end of the Comment column also affects long comments
#endif
        }

#if false
        private void Thumb_DragDelta(object sender, DragDeltaEventArgs e) {
            Thumb senderAsThumb = (Thumb)e.OriginalSource;
            GridViewColumnHeader header = (GridViewColumnHeader)senderAsThumb.TemplatedParent;
            Debug.WriteLine("size changed " + header + ": " + header.Column.ActualWidth);

            ComputeColZeroWidth();
        }

        /// <summary>
        /// Adds up the widths of the first five columns, and stores it in a property.
        /// </summary>
        private void ComputeColZeroWidth() {
            GridView gv = (GridView)codeListView.View;
            double fwidth = 0;
            for (int i = 0; i < 5; i++) {
                fwidth += gv.Columns[i].ActualWidth;
            }
            LongColZeroWidth = (int)Math.Round(fwidth);
        }

        #region INotifyPropertyChanged stuff
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Call this when a notification-worthy property changes value.
        /// 
        /// The CallerMemberName attribute puts the calling property's name in the first arg.
        /// </summary>
        /// <param name="propertyName">Name of property that changed.</param>
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion INotifyPropertyChanged stuff
#endif
    }
}
