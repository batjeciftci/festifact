using System;
using festifact.client.Services;
using festifact.client.ViewModels;
using festifact.models.Dtos.Visitor;

namespace festifact.tests;

public class VisitorSearchTest
{
    private string _filterText;
    private List<VisitorDto> _expectedVisitors;

    public VisitorSearchTest()
    {
        // Arrange
        _filterText = "hans";

        _expectedVisitors = new List<VisitorDto>
        {
            new VisitorDto { VisitorId = 1, Firstname = "hans", Lastname = "graaf", Email = "hans@avans.nl", Residence = "breda" },
        };
    }


    [Fact]
    public void ReturnEmptyList_WhenSearchDoesNotMatch()
    {
        // Arrange
        string filterText = "maui";

        // Act
        var result = SearchVisitors(filterText);

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void Method_ReturnsVisitors_WhenTextMatchesLastname()
    {
        // Arrange
        string filterText = "graaf";

        // Act
        var result = SearchVisitors(filterText);

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);

        var expectedVisitor = _expectedVisitors.First();
        var recentVisitor = result.First();

        Assert.Equal(expectedVisitor.Lastname, recentVisitor.Lastname);
    }

    [Fact]
    public void SearchVisitorMethod_ReturnsVisitors_WhenSearchTextMatches()
    {
        // Act
        var result = SearchVisitors(_filterText);

        // Assert
        Assert.Equal(_expectedVisitors.Count, result.Count);

        for (int i = 0; i < _expectedVisitors.Count; i++)
        {
            var expectedVisitor = _expectedVisitors[i];
            var recentVisitor = result[i];

            // Perform assertions for each visitor
            Assert.Equal(expectedVisitor.VisitorId, recentVisitor.VisitorId);
            Assert.Equal(expectedVisitor.Firstname, recentVisitor.Firstname);
            Assert.Equal(expectedVisitor.Lastname, recentVisitor.Lastname);
            Assert.Equal(expectedVisitor.Email, recentVisitor.Email);
            Assert.Equal(expectedVisitor.Residence, recentVisitor.Residence);
        }
    }

    public List<VisitorDto> SearchVisitors(string filterText)
    {
        var visitors = _expectedVisitors.Where(v => v.Firstname.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();

        if (visitors == null || visitors.Count <= 0)
        {
            visitors = _expectedVisitors.Where(v => v.Email.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();
        }
        else
        {
            return visitors;
        }

        if (visitors == null || visitors.Count <= 0)
        {
            visitors = _expectedVisitors.Where(v => v.Lastname.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();
        }
        else
        {
            return visitors;
        }

        if (visitors == null || visitors.Count <= 0)
        {
            visitors = _expectedVisitors.Where(v => v.Residence.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();
        }
        else
        {
            return visitors;
        }
        // return emptylist of input does not match.
        return visitors;
    }
}
