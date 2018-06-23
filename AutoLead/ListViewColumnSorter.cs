using System;
using System.Collections;
using System.Windows.Forms;

// Token: 0x02000002 RID: 2
public class ListViewColumnSorter : IComparer
{
	// Token: 0x06000002 RID: 2 RVA: 0x00002052 File Offset: 0x00000252
	public ListViewColumnSorter()
	{
		this.ColumnToSort = 0;
		this.OrderOfSort = SortOrder.None;
		this.ObjectCompare = new CaseInsensitiveComparer();
	}

	// Token: 0x06000003 RID: 3 RVA: 0x0000399C File Offset: 0x00001B9C
	public int Compare(object x, object y)
	{
		ListViewItem listViewItem = (ListViewItem)x;
		ListViewItem listViewItem2 = (ListViewItem)y;
		int num = this.ObjectCompare.Compare(listViewItem.SubItems[this.ColumnToSort].Text, listViewItem2.SubItems[this.ColumnToSort].Text);
		bool flag = this.OrderOfSort == SortOrder.Ascending;
		int result;
		if (flag)
		{
			result = num;
		}
		else
		{
			bool flag2 = this.OrderOfSort == SortOrder.Descending;
			if (flag2)
			{
				result = -num;
			}
			else
			{
				result = 0;
			}
		}
		return result;
	}

	// Token: 0x17000001 RID: 1
	public int SortColumn
	{
		// Token: 0x06000005 RID: 5 RVA: 0x00003A24 File Offset: 0x00001C24
		get
		{
			return this.ColumnToSort;
		}
		// Token: 0x06000004 RID: 4 RVA: 0x00002075 File Offset: 0x00000275
		set
		{
			this.ColumnToSort = value;
		}
	}

	// Token: 0x17000002 RID: 2
	public SortOrder Order
	{
		// Token: 0x06000007 RID: 7 RVA: 0x00003A3C File Offset: 0x00001C3C
		get
		{
			return this.OrderOfSort;
		}
		// Token: 0x06000006 RID: 6 RVA: 0x0000207F File Offset: 0x0000027F
		set
		{
			this.OrderOfSort = value;
		}
	}

	// Token: 0x04000001 RID: 1
	private int ColumnToSort;

	// Token: 0x04000002 RID: 2
	private SortOrder OrderOfSort;

	// Token: 0x04000003 RID: 3
	private CaseInsensitiveComparer ObjectCompare;
}
