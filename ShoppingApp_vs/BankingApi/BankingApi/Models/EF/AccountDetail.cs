using System;
using System.Collections.Generic;

namespace BankingApi.Models.EF;

public partial class AccountDetail
{
    public long AccId { get; set; }

    public string AccNo { get; set; } = null!;

    public string AccName { get; set; } = null!;

    public string AccType { get; set; } = null!;

    public decimal? AccBalance { get; set; }
}
