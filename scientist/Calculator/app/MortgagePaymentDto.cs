namespace Calculator.app;

public record MortgagePaymentDto
{
    public int Month { get; set; }
    public decimal StartingBalance { get; set; }
    public decimal Interest { get; set; }
    public decimal MonthlyPayment { get; set; }
    public decimal Principal { get; set; }
    public decimal EndingBalance { get; set; }
}