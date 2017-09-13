using System;
using System.Collections.Generic;
using MarsRover;
using NUnit.Framework;

namespace MarsRoverTest
{
    [TestFixture]
    public class MarsRoverTest
    {
        private Rover _rover;

        [SetUp]
        protected void SetUp()
        {
            _rover = new Rover(new Grid(10, 10, new List<Coordinate>()));
        }

        [TestCase("", "0:0:N")]
        [TestCase("R", "0:0:E")]
        [TestCase("RR", "0:0:S")]
        [TestCase("RRR", "0:0:W")]
        public void Should_move_right(string command, string position)
        {
            Assert.AreEqual(position, _rover.ExecuteCommand(command));
        }

        [TestCase("", "0:0:N")]
        [TestCase("L", "0:0:W")]
        [TestCase("LL", "0:0:S")]
        [TestCase("LLL", "0:0:E")]
        public void Should_move_left(string command, string position)
        {
            Assert.AreEqual(position, _rover.ExecuteCommand(command));
        }

        [TestCase("F", "0:1:N")]
        [TestCase("FFF", "0:3:N")]
        public void Should_move_forvard(string command, string position)
        {
            Assert.AreEqual(position, _rover.ExecuteCommand(command));
        }

        [TestCase("FFFFFFFFFF", "0:0:N")]
        [TestCase("FFFFFFFFFFFFFFF", "0:5:N")]
        public void Should_wrap_from_top_to_bottom_moving_north(string command, string position)
        {
            Assert.AreEqual(position, _rover.ExecuteCommand(command));
        }

        [TestCase("RF", "1:0:E")]
        [TestCase("RFFFFF", "5:0:E")]
        public void Should_move_forvard_right(string command, string position)
        {
            Assert.AreEqual(position, _rover.ExecuteCommand(command));
        }

        [TestCase("RFFFFFFFFFF", "0:0:E")]
        [TestCase("RFFFFFFFFFFFFFFF", "5:0:E")]
        public void Should_wrap_from_right_to_left_moving_east(string command, string position)
        {
            Assert.AreEqual(position, _rover.ExecuteCommand(command));
        }

        [TestCase("LF", "9:0:W")]
        [TestCase("LFFFFF", "5:0:W")]
        public void Should_move_forvard_left(string command, string position)
        {
            Assert.AreEqual(position, _rover.ExecuteCommand(command));
        }

        [TestCase("LLF", "0:9:S")]
        [TestCase("LLFFFFF", "0:5:S")]
        public void Should_move_forward_south(string command, string position)
        {
            Assert.AreEqual(position, _rover.ExecuteCommand(command));
        }

        [TestCase("B", "0:9:N")]
        [TestCase("BBB", "0:7:N")]
        public void Should_move_backvard(string command, string position)
        {
            Assert.AreEqual(position, _rover.ExecuteCommand(command));
        }

        [TestCase("LB", "1:0:W")]
        [TestCase("LBBBBB", "5:0:W")]
        public void Should_move_backvard_left(string command, string position)
        {
            Assert.AreEqual(position, _rover.ExecuteCommand(command));
        }

        [TestCase("LLB", "0:1:S")]
        [TestCase("LLBBBBB", "0:5:S")]
        public void Should_move_backward_south(string command, string position)
        {
            Assert.AreEqual(position, _rover.ExecuteCommand(command));
        }

        [TestCase("FFFF", "O:0:3:N")]
        [TestCase("RFFFFFF", "O:1:0:E")]
        public void Should_stop_at_obstacle(string command, string position)
        {
            var grid = new Grid(10, 10, new List<Coordinate>()
            {
                new Coordinate(0, 4),
                new Coordinate(2, 0)
            });
            var rover = new Rover(grid);

            Assert.AreEqual(position, rover.ExecuteCommand(command));
        }
    }
}